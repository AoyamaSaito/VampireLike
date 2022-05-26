using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _time = 0.05f;
    [SerializeField] PoolEnemy _prefab;
    [SerializeField] Transform _root;

    float _timer = 0.0f;
    float _cRad = 0.0f;
    Vector3 _popPos = new Vector3(0, 0, 0);

    ObjectPool<PoolEnemy> _enemyPool = new ObjectPool<PoolEnemy>();

    private void Start()
    {
        _enemyPool.SetBaseObj(_prefab, _root);
        _enemyPool.SetCapacity(100);

        //GameManager.Instance.Setup();

        //for (int i = 0; i < 900; ++i)
        //{
        //     //_enemyPool[i]
        //}
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _time)
        {
            Spawn();
            _timer -= _time;
        }
    }

    void Spawn()
    {
        var script = _enemyPool.Instantiate();

        _popPos.x = PlayerManager.Instance.Player.transform.position.x + 100 * Mathf.Cos(_cRad);
        _popPos.y = PlayerManager.Instance.Player.transform.position.y + 100 * Mathf.Sin(_cRad);
        script.transform.position = _popPos;
        _cRad += 0.1f;
    }
}
