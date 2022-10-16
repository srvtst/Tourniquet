using Business.Abstract;
using Core.Caching.Abstract;
using Core.RabbitMQ.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class TourniquetManager : ITourniquetService
    {
        ITourniquetDal _tourniquetDal;
        ICacheManager _cacheManager;
        public TourniquetManager(ITourniquetDal tourniquetDal, ICacheManager cacheManager)
        {
            _tourniquetDal = tourniquetDal;
            _cacheManager = cacheManager;
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
                if (_cacheManager.IsThere(key) == true)
                {
                    _cacheManager.Remove(key);
                }
                _tourniquetDal.Exit(tourniquet);
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
                return result;
            }
            else
                return _cacheManager.Get<List<Tourniquet>>(key);
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