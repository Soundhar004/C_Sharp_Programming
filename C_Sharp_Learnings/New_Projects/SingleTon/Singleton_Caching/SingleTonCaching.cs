using System;
using System.Collections.Generic;

public sealed class SingletonCache
{
    private static readonly SingletonCache instance = new SingletonCache();
    private readonly Dictionary<string, string> cache;

    private SingletonCache()
    {
        cache = new Dictionary<string, string>();
    }

    public static SingletonCache Instance => instance;

    // 3️⃣ Add or update a key-value pair
    public void AddOrUpdate(string key, string value)
    {
        cache[key] = value;
    }

    // 2️⃣ Retrieve all key-value pairs
    public Dictionary<string, string> GetAll()
    {
        return new Dictionary<string, string>(cache);
    }

    // 4️⃣ Remove entry by key
    public bool Remove(string key)
    {
        return cache.Remove(key);
    }
}
