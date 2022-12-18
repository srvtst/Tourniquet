using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPersonDal
    {
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        Person GetByEmail(string email);
    }
}