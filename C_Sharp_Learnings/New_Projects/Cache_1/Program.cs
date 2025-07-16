using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_1
{
    class Program
    {

        public sealed class SingletonCache
        {
            private static readonly SingletonCache instance = new SingletonCache();
            private Dictionary<string, string> cache = new Dictionary<string, string>();

            private SingletonCache() { }

            public static SingletonCache Instance
            {
                get { return instance; }
            }

            // Add or Update value for a given key
            public void AddOrUpdate(string key, string value)
            {
                if (cache.ContainsKey(key))
                {
                    cache[key] = value;
                }
                else
                {
                    cache.Add(key, value);
                }
            }

            // Get all key-value pairs
            public Dictionary<string, string> GetAll()
            {
                return new Dictionary<string, string>(cache);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of items:");
            int itemCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemCount; i++)
            {
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                Console.Write("Enter value: ");
                string value = Console.ReadLine();

                SingletonCache.Instance.AddOrUpdate(key, value);
            }

            Console.WriteLine("\nAll Cached Items:");
            var allItems = SingletonCache.Instance.GetAll();

            foreach (var kvp in allItems)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}
