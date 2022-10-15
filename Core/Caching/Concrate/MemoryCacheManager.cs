using Core.Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching.Concrate
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public ICacheEntry Create(object value)
        {
            return _memoryCache.CreateEntry(value);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public bool IsThere(object key)
        {
           return _memoryCache.TryGetValue(key , out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}