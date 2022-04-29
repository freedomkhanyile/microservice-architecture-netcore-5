
using Account.Microservice.Application.Helpers.Constants;
using Account.Microservice.Application.Helpers.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entities = Account.Microservice.Domain.Entities;
namespace Account.Microservice.Application.Services
{
    public interface ITokenService
    {
        string BuildToken(Entities.Account model, string[] roles, DateTime expireDateTime);
        int? ValidateToken(string token);
    }

    public class TokenService : ITokenService
    {
        private readonly SecuritySettings _appSettings;
        private readonly ILogger<TokenService> _logger;
        public TokenService(IOptions<SecuritySettings> appSettings, ILogger<TokenService> logger)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public string BuildToken(Entities.Account model, string[] roles, DateTime expireDateTime)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();


                var claims = new[] {
                new Claim("id", model.Id.ToString()),
                new Claim(ClaimTypes.Name, model.Email)
            }.ToList();

                claims.AddRange(roles.Select(role =>
                                     new Claim(ClaimTypes.Role, role)).ToList());

                var identity = new ClaimsIdentity(claims);

                var key = Encoding.ASCII.GetBytes(_appSettings.AppSecret);

                var signingKey = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    SigningCredentials = signingKey,
                    Subject = identity,
                    Expires = expireDateTime
                });

                return handler.WriteToken(securityToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {0}", ex);
                throw new AppException(ex.Message);
            }
        }

        public int? ValidateToken(string token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.AppSecret);
            try
            {

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
