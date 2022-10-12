using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITourniquetDal
    {
        void Entry(Tourniquet tourniquet);
        void Exit(Tourniquet tourniquet);
        Tourniquet GetByTourniquet(int id);
        List<Tourniquet> GetDayTourniquet(DateTime dateTime);
        List<Tourniquet> GetMonthTourniquet(DateTime dateTime);
    }
}