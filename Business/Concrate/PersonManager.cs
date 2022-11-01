using Business.Abstract;
using Core.Security.Hashing;
using Core.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dto;
using Microsoft.Extensions.Logging;

namespace Business.Concrate
{
    public class PersonManager : IPersonService
    {
        ITokenHelper _tokenHelper;
        IPersonDal _personDal;
        ILogger<PersonManager> _logger;
        public PersonManager(IPersonDal personDal, ITokenHelper tokenHelper, ILogger<PersonManager> logger)
        {
            _tokenHelper = tokenHelper;
            _personDal = personDal;
            _logger = logger;
        }

        public void Add(Person person)
        {
            _personDal.Add(person);
        }

        public AccessToken CreateToken(Person person)
        {
            var token = _tokenHelper.CreateToken(person);
            return token;
        }

        public void Delete(Person person)
        {
            _personDal.Delete(person);
        }

        public Person GetByEmail(string email)
        {
            return _personDal.GetByEmail(email);
        }

        public Person Login(UserForLogin userForLogin)
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
                    return userToCheck;
                }
            }
            else
                throw new Exception("Kullanıcı sistemde mevcut değil.");
        }

        public Person Register(UserForRegister userForRegister, string password)
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
            return person;
        }

        public void Update(Person person)
        {
            _personDal.Update(person);
        }
    }
}