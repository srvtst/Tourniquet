using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate
{
    public class EfPersonDal : IPersonDal
    {

        public void Delete(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var deleted = context.Remove(person);
                context.SaveChanges();
            }
        }
        public Person GetByEmail(string email)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Person>().SingleOrDefault(x => x.Email == email);
            }
        }

        public void Add(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var added = context.Add(person);
                context.SaveChanges();
            }
        }

        public void Update(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var updated = context.Update(person);
                context.SaveChanges();
            }
        }
    }
}