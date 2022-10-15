using Business.Abstract;
using Core.Caching.Abstract;
using Core.RabbitMQ.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.Extensions.Logging;
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
        ICacheManager _cacheManager;
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

        public List<Tourniquet> GetAll()
        {
            var result = _tourniquetDal.GetAll();
            return result;
            _cacheManager.Create(result);
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
            return _tourniquetDal.GetMonthTourniquet(dateTime);
        }
    }
}