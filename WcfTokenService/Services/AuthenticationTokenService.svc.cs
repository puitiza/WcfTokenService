namespace WcfTokenService.Services
{
    using System.Security.Authentication;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using WcfTokenService.Business;
    using WcfTokenService.Interfaces;
    using WcfTokenService.Model;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationTokenService : IAuthenticationTokenService
    {
        public string Authenticate(Credentials creds)
        {
            ICredentialsValidator validator = new CodeExampleCredentialsValidator();
            if (validator.IsValid(creds))
                return new CodeExampleTokenBuilder().Build(creds);
            throw new InvalidCredentialException("Invalid credentials");
        }

    }
}
