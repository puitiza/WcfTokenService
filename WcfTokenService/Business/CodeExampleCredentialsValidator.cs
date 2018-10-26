namespace WcfTokenService.Business
{
    using WcfTokenService.Interfaces;
    using WcfTokenService.Model;
    public class CodeExampleCredentialsValidator : ICredentialsValidator
    {
        public bool IsValid(Credentials creds)
        {
            // Check for valid creds here
            // I compare using hashes only for example purposes
            if (creds.User == "user1" && Hash.Get(creds.Password, Hash.HashType.SHA256) == Hash.Get("pass1", Hash.HashType.SHA256))
                return true;
            return false;
        }
    }
}