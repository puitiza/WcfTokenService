namespace WcfTokenService.Behaviors
{
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using System.ServiceModel.Web;
    using WcfTokenService.Business;
    using WcfTokenService.Database;
    using WcfTokenService.Interfaces;

    public class TokenValidationInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Return BadRequest if request is null
            if (WebOperationContext.Current == null) { throw new WebFaultException(HttpStatusCode.BadRequest); }

            // Get Token from header
            var token = WebOperationContext.Current.IncomingRequest.Headers["Token"];

            // Validate the Token
            using (var dbContext = new BasicTokenDbContext())
            {
                ITokenValidator validator = new DatabaseTokenValidator(dbContext);
                if (!validator.IsValid(token))
                {
                    throw new WebFaultException(HttpStatusCode.Forbidden);
                }
                // Add User ids to the header so the service has them if needed
                WebOperationContext.Current.IncomingRequest.Headers.Add("User", validator.Token.User.Username);
                WebOperationContext.Current.IncomingRequest.Headers.Add("UserId", validator.Token.User.Id.ToString());
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}