using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace Account.Microservice.Core.Application.Services
{
    public class RSAKeyHelper
    {
        public static RSAParameters GenerateKey()
        {
            using var key = new RSACryptoServiceProvider(2048);
            return key.ExportParameters(true);
        }
    }
    public class TokenAuthOption
    {
        public static string Audience { get; } = "Account.Api.Audience";
        public static string Issuer { get; } = "Account.Api.Issuer";

        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(60);
        public static string TokenType { get; } = "Bearer";
    }
}
