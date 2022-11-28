using Business.Abstract;
using Business.Mailing.Abstract;
using Business.MessageBroker.RabbitMQ.Abstract;
using Core.CrossCuttingConcerns.Caching.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dto;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Business.Concrate
{
    public class TourniquetManager : ITourniquetService
    {
        ITourniquetDal _tourniquetDal;
        ILogger<TourniquetManager> _logger;
        IPublisherService _publisherService;
        IMailSender _mailSender;
        ICacheManager _cacheManager;
        IConsumerService _consumerService;
        public TourniquetManager(ITourniquetDal tourniquetDal, ILogger<TourniquetManager> logger
            , IPublisherService publisherService, IMailSender mailSender, ICacheManager cacheManager, IConsumerService consumerService)
        {
            _tourniquetDal = tourniquetDal;
            _logger = logger;
            _publisherService = publisherService;
            _mailSender = mailSender;
            _cacheManager = cacheManager;
            _consumerService = consumerService;
        }

        public void Entry(Tourniquet tourniquet)
        {
            _tourniquetDal.Entry(tourniquet);
            _publisherService.Publish(tourniquet);
            _consumerService.Start();
            string fromAddress = GetTourniquetByPerson(tourniquet.PersonId).Email;
            _mailSender.SendMail(fromAddress, $"Turnikeden {tourniquet.DateOfEntry.ToString()} giriş yapıldı");
            _logger.LogInformation("Turnikeden giriş yapıldı");
        }

        public void Exit(Tourniquet tourniquet)
        {
            _tourniquetDal.Exit(tourniquet);
            _publisherService.Publish(tourniquet);
            _consumerService.Start();

            //string fromAddress = GetTourniquetByPerson(tourniquet.PersonId).Email;
            //_mailSender.SendMail(fromAddress, $"Turnikeden {tourniquet.ExitDate.ToString()} çıkış yapıldı.");
            _logger.LogInformation("Turnikeden çıkış yapıldı");
        }

        public List<Tourniquet> GetAll()
        {
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (!_cacheManager.IsThere(key))
            {
                var result = _tourniquetDal.GetAll();
                _cacheManager.Add(key, result, 40);
                _logger.LogInformation("Veri tabanından listeleme yapıldı.");
                return result;
            }
            else
            {
                _logger.LogInformation("Cache ten listeleme yapıldı.");
                return _cacheManager.Get<List<Tourniquet>>(key);
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
            return _tourniquetDal.GetMonthTourniquet(dateTime);
        }

        public TourniquetPerson GetTourniquetByPerson(int personId)
        {
            return _tourniquetDal.GetTourniquetByPerson(personId);
        }
    }
}