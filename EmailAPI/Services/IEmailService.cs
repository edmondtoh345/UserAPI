namespace EmailAPI.Services
{
    public interface IEmailService
    {
        void RegisteredEmail(string email);
        void ForgetPasswordEmail(string email, string password);
        void BlockedEmail(string email);
    }
}
