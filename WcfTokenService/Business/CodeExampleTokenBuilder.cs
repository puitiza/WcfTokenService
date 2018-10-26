namespace WcfTokenService.Business
{
    using System.Security.Authentication;
    using WcfTokenService.Interfaces;
    using WcfTokenService.Model;
    public class CodeExampleTokenBuilder : ITokenBuilder
    {
        internal static string StaticToken = "{B709CE08-D2DE-4201-962B-3BBAC74C5952}";

        public string Build(Credentials creds)
        {
            if (new CodeExampleCredentialsValidator().IsValid(creds))
                return StaticToken;
            throw new AuthenticationException();
        }
    }
}