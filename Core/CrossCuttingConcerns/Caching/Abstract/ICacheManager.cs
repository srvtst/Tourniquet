using Castle.DynamicProxy;

namespace Core.CrossCuttingConcerns.Caching.Abstract
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