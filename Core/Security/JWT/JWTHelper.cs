using Entities.Concrate;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _tokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(Person person)
        {
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.TokenExpiration);
            var key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(key);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: _tokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.WriteToken(securityToken);

            AccessToken accessToken = new AccessToken
            {
                Token = token,
                ExpirationDate = _tokenExpiration
            };

            return accessToken;
        }
    }
}