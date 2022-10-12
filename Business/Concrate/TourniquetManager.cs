using Business.Abstract;
using Core.RabbitMQ.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class TourniquetManager : ITourniquetService
    {
        ITourniquetDal _tourniquetDal;
        public TourniquetManager(ITourniquetDal tourniquetDal)
        {
            _tourniquetDal = tourniquetDal;
        }

        public void Entry(Tourniquet tourniquet)
        {
            _tourniquetDal.Entry(tourniquet);
        }

        public void Exit(Tourniquet tourniquet)
        {
            var result = GetByTourniquet(tourniquet.Id);
            if (result != null)
            {
                _tourniquetDal.Exit(tourniquet);
            }
        }

        public Tourniquet GetByTourniquet(int id)
        {
            return _tourniquetDal.GetByTourniquet(id);
        }

        public List<Tourniquet> GetDayTourniquet(DateTime dateTime)
        {
            return _tourniquetDal.GetDayTourniquet(dateTime);
        }

        public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        {
            return _tourniquetDal.GetDayTourniquet(dateTime);
        }
    }
}