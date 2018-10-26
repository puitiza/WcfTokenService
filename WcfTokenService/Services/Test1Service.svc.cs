namespace WcfTokenService.Services
{
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.Web;
    using WcfTokenService.Business;
    using WcfTokenService.Interfaces;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Test1Service : ITest1Service
    {
        public string Test()
        {
            var token = HttpContext.Current.Request.Headers["Token"];
            ITokenValidator validator = new CodeExampleTokenValidator();
            if (validator.IsValid(token))
            {
                return "Your token worked!";
            }
            else
            {
                return "Your token failed!";
            }
        }
    }
}
