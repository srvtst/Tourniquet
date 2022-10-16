using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching.Abstract
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Remove(string key);
        void Add(string key, object value, int duration);
        bool IsThere(string key);
    }
}