namespace WcfTokenService.Interfaces
{
    using WcfTokenService.Database;

    public interface ITokenValidator
    {
        bool IsValid(string token);
        Token Token { get; set; }
    }
}
