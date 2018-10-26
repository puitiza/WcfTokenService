namespace WcfTokenService.Interfaces
{
    public interface ITokenValidator
    {
        bool IsValid(string token);

    }
}
