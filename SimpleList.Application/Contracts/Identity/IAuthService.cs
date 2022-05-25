using SimpleList.Application.Models.Identity;

namespace SimpleList.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
