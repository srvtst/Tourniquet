using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate
{
    public class EfTourniquetDal : ITourniquetDal
    {
        public void Entry(Tourniquet tourniquet)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var entry = context.Add(tourniquet);
                context.SaveChanges();
            }
        }

        public void Exit(Tourniquet tourniquet)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var exit = context.Update(tourniquet);
                context.SaveChanges();
            }
        }

        public List<Tourniquet> GetAll()
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Tourniquet>().ToList();
            }
        }

        public Tourniquet GetByTourniquet(int id)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Tourniquet>().SingleOrDefault(t => t.Id == id);
            }
        }
        public List<Tourniquet> GetDayTourniquet(DateTime dateTime)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Tourniquet>().Where(t => t.DateOfEntry.Day == dateTime.Day || t.ExitDate.Day == dateTime.Day).ToList();
            }
        }

        public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Tourniquet>().Where(t => t.DateOfEntry.Month == dateTime.Month || t.ExitDate.Month == dateTime.Month).ToList();
            }
        }
    }
}