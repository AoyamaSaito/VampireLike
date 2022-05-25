using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    bool _stop = false;

    Rigidbody2D _rb;
    PlayerManager _playerManager;

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
    }
    
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        if (_stop) return;

        _playerManager = PlayerManager.Instance;
        Vector3 dir = _playerManager.ReturnPlayerDirection(transform.position).normalized;
        _rb.velocity = dir * _speed;
    }

    void Pause()
    {
        _stop = true;
        _rb.angularVelocity = 0;
    }

    void Resume()
    {
        _stop = false;
    }
}
