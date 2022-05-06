namespace SimpleList.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
