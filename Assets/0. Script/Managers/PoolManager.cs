using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    private readonly Dictionary<string, object> pools = new Dictionary<string, object>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Register<T>(string key, T prefab, int size) where T : Component
    {
        if (pools.ContainsKey(key))
        {
            Debug.LogWarning($"[Pool] Key already registered: {key}");
            return;
        }

        ObjectPool<T> pool = new ObjectPool<T>(prefab, size);
        pools.Add(key, pool);
    }

    public T Get<T>(string key, Vector3 pos, Quaternion rot) where T : Component
    {
        if (pools.TryGetValue(key, out var poolObj))
        {
            ObjectPool<T> pool = poolObj as ObjectPool<T>;
            if (pool != null)
            {
                T obj = pool.Get();
                obj.transform.SetPositionAndRotation(pos, rot);
                return obj;
            }
        }

        Debug.LogWarning($"[Pool] No pool found for key: {key}");
        return null;
    }

    public void Return<T>(string key, T obj) where T : Component
    {
        if (pools.TryGetValue(key, out var poolObj))
        {
            ObjectPool<T> pool = poolObj as ObjectPool<T>;
            if (pool != null)
            {
                pool.Return(obj);
                return;
            }
        }

        Debug.LogWarning($"[Pool] No pool found for key: {key}");
    }
}
