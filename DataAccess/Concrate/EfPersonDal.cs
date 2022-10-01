using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate
{
    public class EfPersonDal : IPersonDal
    {
        public List<Person> GetAll()
        {
            using (TourniquetContext context = new TourniquetContext()) 
            {
                return context.Set<Person>().ToList();
            }
        }
    }
}