namespace WcfTokenService.Services
{
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using WcfTokenService.Model;

    [ServiceContract]
    public interface IAuthenticationTokenService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string Authenticate(Credentials creds);
    }
}
