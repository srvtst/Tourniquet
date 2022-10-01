using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
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

        }

        public void Delete(Person person)
        {

        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public Person GetByPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {

        }
    }
}
