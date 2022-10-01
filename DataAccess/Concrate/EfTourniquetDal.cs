using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var exit = context.Add(tourniquet);
                context.SaveChanges();
            }
        }
    }
}