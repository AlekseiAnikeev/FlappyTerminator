using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: prefab => prefab.gameObject.SetActive(true),
            actionOnRelease: prefab => prefab.gameObject.SetActive(false),
            actionOnDestroy: prefab => Destroy(prefab.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    protected abstract Vector3 GetPosition();
    protected abstract void Spawn();
    
    protected T GetObject()
    {
        return _pool.Get();
    }

    protected void RemoveToPool(T obj)
    {
        _pool.Release(obj);
    }

    private T Create()
    {
        return Instantiate(_prefab);
    }
}