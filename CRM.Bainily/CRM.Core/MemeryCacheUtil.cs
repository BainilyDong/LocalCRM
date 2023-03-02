using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace CRM.Core
{
    public class MemeryCacheUtil
    {
		public static T GetCache<T>(string key)
		{
			T result;
			try
			{
				result = (T)((object)MemoryCache.Default[key]);
			}
			catch (Exception)
			{
				result = default(T);
			}
			return result;
		}
		public static void SetCache(string key, object obj, int seconds = 300)
		{
			MemoryCache.Default.Set(key, obj, new CacheItemPolicy
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds((double)seconds)
			}, null);
		}
		public static bool ContainsKey(string key)
		{
			return MemoryCache.Default.Contains(key, null);
		}
		public static void RemoveCache(string key)
		{
			MemoryCache.Default.Remove(key, null);
		}
	}
}
