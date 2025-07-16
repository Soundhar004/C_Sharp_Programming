using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Caching
{
    class Program
    {
        static void Main()
        {
            // 1️⃣ Add initial entries to cache
            Console.Write("How many entries do you want to add? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                Console.Write("Enter value: ");
                string value = Console.ReadLine();

                SingletonCache.Instance.AddOrUpdate(key, value);
            }

            // 2️⃣ Retrieve and display current cache
            Console.WriteLine("\nCurrent Cache:");
            foreach (var item in SingletonCache.Instance.GetAll())
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // 3️⃣ Update or add more entries
            Console.Write("\nDo you want to add/update any entries? (yes/no): ");
            string updateAnswer = Console.ReadLine();

            if (updateAnswer.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("How many entries to update/add? ");
                int updates = int.Parse(Console.ReadLine());

                for (int i = 0; i < updates; i++)
                {
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();

                    Console.Write("Enter new value: ");
                    string value = Console.ReadLine();

                    SingletonCache.Instance.AddOrUpdate(key, value);
                }
            }

            // 4️⃣ Remove a key
            Console.Write("\nDo you want to remove any entry? (yes/no): ");
            string removeAnswer = Console.ReadLine();

            if (removeAnswer.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter key to remove: ");
                string keyToRemove = Console.ReadLine();

                bool removed = SingletonCache.Instance.Remove(keyToRemove);
                Console.WriteLine(removed ? "Key removed successfully." : "Key not found.");
            }

            // Final cache state
            Console.WriteLine("\n🔍 Final Cache:");
            foreach (var item in SingletonCache.Instance.GetAll())
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
    }

}
