using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleList.Application.Constants;
using SimpleList.Application.Contracts.Identity;
using SimpleList.Application.Models.Identity;
using SimpleList.Application.Utils.Encode;
using SimpleList.Application.Utils.Validations;
using SimpleList.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleList.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            Guard.Against.IsNull(user, $"user with {request.Email} doesnt exist");

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                // TODO: Crear custom exception
                throw new Exception($"wrong password");
            }

            var token = await GenerateTokenAsync(user);
            return new AuthResponse
            {
                Email = user.Email,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName
            };
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            await CheckExistingUserAsync(request);

            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception($"{result.Errors}");
            }

            //TODO: create roles constants
            await _userManager.AddToRoleAsync(user, "Operator");

            var token = await GenerateTokenAsync(user);
            return new RegistrationResponse
            {
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        private async Task CheckExistingUserAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception($"Email {request.Email} is already register");
            }

            existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new Exception($"Username {request.UserName} is already register");
            }
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            IEnumerable<Claim> claims = await GetUserClaimsAsync(user);

            var symmetricSecurityKey = new SymmetricSecurityKey(EncodingUtils.EncodeToBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
        }

        private async Task<IEnumerable<Claim>> GetUserClaimsAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.UserId, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
        }
    }
}
