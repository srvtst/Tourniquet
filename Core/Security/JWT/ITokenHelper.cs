using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT
{
    public interface ITokenHelper
    {
        void CreateToken(Person person, List<Claim> claims);
    }
}