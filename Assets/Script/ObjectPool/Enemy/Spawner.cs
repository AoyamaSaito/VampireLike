using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _time = 5f;
    [SerializeField] float _spawnPosition = 10;
    [SerializeField] int _spawnCount = 100;
    [SerializeField] PoolEnemy _prefab;
    [SerializeField] Transform _root;

    float _timer = 0.0f;
    float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);

    ObjectPool<PoolEnemy> _enemyPool = new ObjectPool<PoolEnemy>();
    public ObjectPool<PoolEnemy> EnemyPool => _enemyPool;

    private void Start()
    {
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(_spawnCount);

        GameManager.Instance.Setup();
    }

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
    }

    private void Spawn(EnemyParam param = default)
    {
        var enemy = _enemyPool.Instantiate();
        //if(enemy.TryGetComponent<EnemyParam>(out param))
        //{
        //    param.OnDeath += enemy.Destroy;
        //}

        _popPos.x = PlayerManager.Instance.Player.transform.position.x + _spawnPosition * Mathf.Cos(_cRad);
        _popPos.y = PlayerManager.Instance.Player.transform.position.y + _spawnPosition * Mathf.Sin(_cRad);
        enemy.transform.position = _popPos;
        _cRad += 1f;
    }
}
