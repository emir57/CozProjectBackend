using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memory;

        public MemoryCacheManager(IMemoryCache memory)
        {
            _memory = memory;
        }

        public void Add(string key, object value, int duration)
        {
            _memory.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public object Get(string key)
        {
            return _memory.Get(key);
        }

        public T Get<T>(string key)
        {
            return _memory.Get<T>(key);
        }

        public bool IsAdd(string key)
        {
            return _memory.TryGetValue(key, out _);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memory) as dynamic;
            List<ICacheEntry> cacheEntries = new List<ICacheEntry>();
            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheEntries.Add(cacheItemValue);
            }
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            var keysToRemove = cacheEntries.Where(x => regex.IsMatch(x.Key.ToString())).Select(x => x.Key).ToList();
            foreach (var key in keysToRemove)
            {
                _memory.Remove(key);
            }
        }
    }
}
