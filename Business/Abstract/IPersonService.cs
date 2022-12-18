using Core.Security.Jwt;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<Person> Login(UserForLogin userForLogin);
        IDataResult<Person> Register(UserForRegister userForRegister, string password);
        IDataResult<AccessToken> CreateToken(Person person);
        IDataResult<Person> GetByEmail(string email);
        IResult Add(Person person);
        IResult Update(Person person);
        IResult Delete(Person person);
    }
}