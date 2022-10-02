using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonDal
    {
        List<Person> GetAll();
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}