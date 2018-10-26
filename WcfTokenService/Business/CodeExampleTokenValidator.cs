namespace WcfTokenService.Business
{
    using WcfTokenService.Interfaces;
    public class CodeExampleTokenValidator : ITokenValidator
    {
        public bool IsValid(string token)
        {
            return CodeExampleTokenBuilder.StaticToken == token;
        }
    }
}