using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] float _time = 5f;
    [SerializeField] float _spawnPosition = 10;
    [SerializeField] int _spawnCount = 100;
    [SerializeField] Exp _prefab;
    [SerializeField] Transform _root;

    ObjectPool<Exp> objectPool = new ObjectPool<Exp>();
    public ObjectPool<Exp> ObjectPool => objectPool;

    private void Start()
    {
        objectPool.SetBaseObj(_prefab, _root);
        objectPool.SetCapacity(_spawnCount);

        GameManager.Instance.Setup();
    }
}
