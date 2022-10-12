using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                var exit = context.Update(tourniquet);
                context.SaveChanges();
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
            throw new NotImplementedException();
        }

        public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        //public List<Tourniquet> GetDayTourniquet(DateTime dateTime)
        //{
        //    using (TourniquetContext context = new TourniquetContext())
        //    {

        //    }
        //}

        //public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        //{
        //    using (TourniquetContext context = new TourniquetContext())
        //    {

        //    }
        //}
    }
}