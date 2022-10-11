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
        IPublisherService _publisherService;
        public TourniquetManager(ITourniquetDal tourniquetDal)
        {
            _tourniquetDal = tourniquetDal;
        }

        public void Entry(Tourniquet tourniquet)
        {
            _tourniquetDal.Entry(tourniquet);
            if (tourniquet.Status == true)
            {
                string message = "Giriş Kuyruğu";
               // _publisherService.Enqueue<Tourniquet>(tourniquet, message);
            }
        }

        public void Exit(Tourniquet tourniquet)
        {
            _tourniquetDal.Exit(tourniquet);
        }
    }
}