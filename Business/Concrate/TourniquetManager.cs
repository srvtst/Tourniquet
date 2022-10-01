using Business.Abstract;
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
            _tourniquetDal.Exit(tourniquet);
        }
    }
}