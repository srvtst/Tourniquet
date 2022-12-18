using Business.Abstract;
using Business.Contants;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        ITokenHelper _tokenHelper;
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal, ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _personDal = personDal;
        }

        public IResult Add(Person person)
        {
            _personDal.Add(person);
            return new Result(true, Message.PersonAdded);
        }

        public IDataResult<AccessToken> CreateToken(Person person)
        {
            var token = _tokenHelper.CreateToken(person);
            return new SuccessDataResult<AccessToken>(token);
        }

        public IResult Delete(Person person)
        {
            _personDal.Delete(person);
            return new Result(true, Message.PersonDeleted);
        }

        public IDataResult<Person> GetByEmail(string email)
        {
            return new SuccessDataResult<Person>(_personDal.GetByEmail(email), Message.PersonGetByMail);
        }

        public IDataResult<Person> Login(UserForLogin userForLogin)
        {
            var userToCheck = _personDal.GetByEmail(userForLogin.Email);
            if (userToCheck != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash))
                {
                    throw new Exception("Kullanıcı parolası hatalı");
                }
                else
                {
                    return new SuccessDataResult<Person>(userToCheck, Message.PersonLogin);
                }
            }
            else
                return new ErrorDataResult<Person>("Kullanıcı sistemde mevcut değil.");
        }

        public IDataResult<Person> Register(UserForRegister userForRegister, string password)
        {
            string passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var person = new Person
            {
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                Email = userForRegister.Email,
                PhoneNumber = userForRegister.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _personDal.Add(person);
            return new SuccessDataResult<Person>(person, Message.PersonRegister);
        }

        public IResult Update(Person person)
        {
            _personDal.Update(person);
            return new Result(true, Message.PersonDeleted);
        }
    }
}