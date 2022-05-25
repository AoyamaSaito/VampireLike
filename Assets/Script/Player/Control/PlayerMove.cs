using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 5;

    bool _stop = false;

    Rigidbody2D _rb;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.OnPause += Pause;
            gameManager.OnResume += Resume;
        }
    }

    void Update()
    {
        Move(PlayerInput());
    }

    float _h = 0;
    float _v = 0;
    Vector2 PlayerInput()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        return new Vector2(_h, _v);
    }
    
    void Move(Vector2 _dir)
    {
        if (_stop) return;

        _rb.velocity = _dir.normalized * _speed;
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