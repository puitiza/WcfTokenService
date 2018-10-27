namespace WcfTokenService.Services
{
    using System.Security.Authentication;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using WcfTokenService.Business;
    using WcfTokenService.Database;
    using WcfTokenService.Interfaces;
    using WcfTokenService.Model;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationTokenService : IAuthenticationTokenService
    {
        public string Authenticate(Credentials creds)
        {
            using (var dbContext = new BasicTokenDbContext())
            {
                ICredentialsValidator validator = new DatabaseCredentialsValidator(dbContext);
                if (validator.IsValid(creds))
                    return new DatabaseTokenBuilder(dbContext).Build(creds);
                throw new InvalidCredentialException("Invalid credentials");
            }
        }

    }
}
