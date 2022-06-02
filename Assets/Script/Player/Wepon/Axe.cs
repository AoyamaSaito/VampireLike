using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IObjectPool
{
    [SerializeField] float _movePower = 30f;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _image;

    bool _isActrive = false;
    public bool IsActive => _isActrive;
    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }
    public void Create()
    {
        _image.enabled = true;
        _rb.simulated = true;

        transform.position = PlayerManager.Instance.Player.transform.position;

        Vector3 dir = new Vector3(Random.Range(0.5f, -0.5f), Random.Range(0.5f, -0.5f), 0).normalized;
        _rb.AddForce(dir * _movePower, ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }
}
