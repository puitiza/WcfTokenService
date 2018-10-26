namespace WcfTokenService.Interfaces
{
    using WcfTokenService.Model;

    public interface ICredentialsValidator
    {
        bool IsValid(Credentials creds);
    }
}
