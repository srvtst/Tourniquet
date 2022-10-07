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
        List<Person> GetAll();
        Person GetByPerson(int personId);
        //Person Login(UserForLogin userForLogin);
        Person Register(UserForRegister userForRegister, string password);
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        Person GetByEmail(string email);
    }
}