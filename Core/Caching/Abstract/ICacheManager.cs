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
        void Remove(string key);
        ICacheEntry Create(object value);
        bool IsThere(object key);
    }
}