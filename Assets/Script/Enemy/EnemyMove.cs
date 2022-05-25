using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    Rigidbody2D _rb;
    PlayerManager _playerManager;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        _playerManager = PlayerManager.Instance;
        Vector3 dir = _playerManager.ReturnPlayerDirection(transform.position).normalized;
        _rb.velocity = dir * _speed;
    }
}
