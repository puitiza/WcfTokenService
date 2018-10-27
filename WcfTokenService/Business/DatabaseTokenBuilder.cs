﻿namespace WcfTokenService.Business
{
    using System;
    using System.Linq;
    using System.Security.Authentication;
    using System.Security.Cryptography;
    using WcfTokenService.Database;
    using WcfTokenService.Interfaces;
    using WcfTokenService.Model;

    public class DatabaseTokenBuilder : ITokenBuilder
    {
        public static int TokenSize = 100;
        private readonly BasicTokenDbContext _DbContext;

        public DatabaseTokenBuilder(BasicTokenDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public string Build(Credentials creds)
        {
            if (!new DatabaseCredentialsValidator(_DbContext).IsValid(creds))
            {
                throw new AuthenticationException();
            }
            var token = BuildSecureToken(TokenSize);
            var user = _DbContext.Users.SingleOrDefault(u => u.Username.Equals(creds.User, StringComparison.CurrentCultureIgnoreCase));
            _DbContext.Tokens.Add(new Token { Text = token, User = user, CreateDate = DateTime.Now });
            _DbContext.SaveChanges();
            return token;
        }

        private string BuildSecureToken(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}