using Core.Security.Jwt;
using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        Person Login(UserForLogin userForLogin);
        Person Register(UserForRegister userForRegister, string password);
        AccessToken CreateToken(Person person);
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        Person GetByEmail(string email);
    }
}