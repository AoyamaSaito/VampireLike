using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    bool _isMove = false;

    Rigidbody2D _rb;
    PlayerManager _playerManager;
    PoolEnemy _poolEnemy;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameManager gameManager = GameManager.Instance;
        if( gameManager != null )
        {
            gameManager.OnPause += Pause;
            gameManager.OnResume += Resume;
        }

        _poolEnemy = GetComponent<PoolEnemy>();
        _poolEnemy.ObserveEveryValueChanged(_poolEnemy => _poolEnemy.IsActive)
            .Subscribe(value => Active(value));

    }
    
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        if (!_isMove) return;

        _playerManager = PlayerManager.Instance;
        Vector3 dir = _playerManager.ReturnPlayerDirection(transform.position).normalized;
        _rb.velocity = dir * _speed;
    }

    void Active(bool b)
    {
        _isMove = b!;
        _rb.simulated = b;
    }

    void Pause()
    {
        _isMove = true;
        _rb.Sleep();
        _rb.angularVelocity = 0;
    }

    void Resume()
    {
        _isMove = false;
        _rb.WakeUp();
    }
}
