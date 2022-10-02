using Business.Abstract;
using Core.Security;
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

        public Person GetByPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public Person Login(UserForLogin userForLogin)
        {
            throw new NotImplementedException();
        }

        public Person Register(UserForRegister userForRegister , string password)
        {
            byte[] passwordSalt , passwordHash;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var person = new Person
            {
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                Email = userForRegister.Email,
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
