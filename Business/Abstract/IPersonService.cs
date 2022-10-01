using Entities.Concrate;
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
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}