namespace UserAPI.Services
{
    public interface ITokenAuthenticator
    {
        bool Authenticate(string token);
    }
}
