namespace WcfTokenService.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Test1Service : ITest1Service
    {
        public string TestPost()
        {
            return string.Format("Your token worked! User: {0} User Id: {1}",
            WebOperationContext.Current.IncomingRequest.Headers["UserId"],
            WebOperationContext.Current.IncomingRequest.Headers["User"]);
        }

        public string TestGet()
        {
            return string.Format("Your authentication worked! User: {0} User Id: {1}",
                WebOperationContext.Current.IncomingRequest.Headers["User"],
                WebOperationContext.Current.IncomingRequest.Headers["UserId"]);
        }
    }
}
