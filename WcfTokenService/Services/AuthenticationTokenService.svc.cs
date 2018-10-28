namespace WcfTokenService.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using WcfTokenService.Business;
    using WcfTokenService.Database;
    using WcfTokenService.Model;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationTokenService : IAuthenticationTokenService
    {
        public string Authenticate(Credentials creds)
        {
            if (creds == null && WebOperationContext.Current != null)
            {
                var basicAuthHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                if (!string.IsNullOrWhiteSpace(basicAuthHeader))
                    creds = new BasicAuth(basicAuthHeader).Creds;
            }
            using (var dbContext = new BasicTokenDbContext())
            {
                return new DatabaseTokenBuilder(dbContext).Build(creds);
            }
        }

    }
}
