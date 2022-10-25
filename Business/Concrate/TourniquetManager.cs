using Business.Abstract;
using Core.Caching.Abstract;
using Core.RabbitMQ.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Business.Concrate
{
    public class TourniquetManager : ITourniquetService
    {
        ITourniquetDal _tourniquetDal;
        ICacheManager _cacheManager;
        ILogger<TourniquetManager> _logger;
        IPublisherService _publisherService;
        public TourniquetManager(ITourniquetDal tourniquetDal, ICacheManager cacheManager, ILogger<TourniquetManager> logger, IPublisherService publisherService)
        {
            _tourniquetDal = tourniquetDal;
            _cacheManager = cacheManager;
            _logger = logger;
            _publisherService = publisherService;
        }

        public void Entry(Tourniquet tourniquet)
        {
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (_cacheManager.IsThere(key) == true)
            {
                _cacheManager.Remove(key);
            }
            _tourniquetDal.Entry(tourniquet);
            _publisherService.Enqueue(tourniquet);
            _logger.LogInformation("Turnikeden giriş yapıldı");
        }

        public void Exit(Tourniquet tourniquet)
        {
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            var result = GetByTourniquet(tourniquet.Id);
            if (result != null)
            {
                if (tourniquet.DateOfEntry.Hour - tourniquet.ExitDate.Hour > 8)
                {
                    _publisherService.Enqueue(tourniquet);
                }
                if (_cacheManager.IsThere(key) == true)
                {
                    _cacheManager.Remove(key);
                }
                _tourniquetDal.Exit(tourniquet);
                _logger.LogInformation("Turnikeden çıkış yapıldı");
            }
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
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (!_cacheManager.IsThere(key))
            {
                var result = _tourniquetDal.GetByTourniquet(id);
                _cacheManager.Add(key, result, 10);
                return result;
            }
            else
                return _cacheManager.Get<Tourniquet>(key);
        }

        public List<Tourniquet> GetDayTourniquet(DateTime dateTime)
        {
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (!_cacheManager.IsThere(key))
            {
                var result = _tourniquetDal.GetDayTourniquet(dateTime);
                _cacheManager.Add(key, result, 10);
                return result;
            }
            else
                return _cacheManager.Get<List<Tourniquet>>(key);
        }

        public List<Tourniquet> GetMonthTourniquet(DateTime dateTime)
        {
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (!_cacheManager.IsThere(key))
            {
                var result = _tourniquetDal.GetMonthTourniquet(dateTime);
                _cacheManager.Add(key, result, 10);
                return result;
            }
            else
                return _cacheManager.Get<List<Tourniquet>>(key);
        }
    }
}