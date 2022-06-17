using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 5;

    float _addSpeed = 0;
    bool _stop = false;

    Rigidbody2D _rb;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _addSpeed = 0;

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


    Vector2 PlayerInput(float h = 0, float v = 0)
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        return new Vector2(h, v);
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
