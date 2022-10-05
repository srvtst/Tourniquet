using Business.Abstract;
using Core.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public void Add(Person person)
        {
            _personDal.Add(person);
        }

        public void Delete(Person person)
        {
            _personDal.Delete(person);
        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public Person GetByEmail(string email)
        {
            return _personDal.GetByEmail(email);
        }

        public Person GetByPerson(int personId)
        {
            return _personDal.GetByPerson(personId);
        }

        public Person Login(UserForLogin userForLogin)
        {
            var userToCheck = _personDal.GetByEmail(userForLogin.Email);
            if (userToCheck != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordSalt, userToCheck.PasswordSalt))
                {
                    throw new Exception("Kullanıcı parolası hatalı");
                }
                else
                    return userToCheck;
            }
            else
                throw new Exception("Kullanıcı sistemde mevcut değil.");
        }

        public Person Register(UserForRegister userForRegister, string password)
        {
            byte[] passwordSalt, passwordHash;
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