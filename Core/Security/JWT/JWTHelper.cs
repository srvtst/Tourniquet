using Entities.Concrate;
using Microsoft.Extensions.Configuration;

namespace Core.Security.JWT
{
    public class JWTHelper : ITokenHelper
    {
        IConfiguration Configuration {get;}
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public void CreateToken(Person person, List<Claim> claims)
        {

        }


    }
}