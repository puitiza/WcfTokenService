namespace WcfTokenService.Services
{
    using System.ServiceModel.Activation;
    using System.Web;
    using WcfTokenService.Business;
    using WcfTokenService.Database;
    using WcfTokenService.Interfaces;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Test1Service : ITest1Service
    {
        public string Test()
        {
            var token = HttpContext.Current.Request.Headers["Token"]; // This works whether aspNetCompatibilityEnabled is true of false.
            using (var dbContext = new BasicTokenDbContext())
            {
                ITokenValidator validator = new DatabaseTokenValidator(dbContext);
                return validator.IsValid(token) ? "Your token worked!" : "Your token failed!";
            }
        }
    }
}
