using Core.Security.Jwt;
using Entities.Concrate;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPersonService
    {
        Person Login(UserForLogin userForLogin);
        Person Register(UserForRegister userForRegister, string password);
        AccessToken CreateToken(Person person);
        Person GetByEmail(string email);
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}