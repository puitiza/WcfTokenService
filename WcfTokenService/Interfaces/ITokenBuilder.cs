namespace WcfTokenService.Interfaces
{
    using WcfTokenService.Model;

    interface ITokenBuilder
    {
        string Build(Credentials creds);
    }
}
