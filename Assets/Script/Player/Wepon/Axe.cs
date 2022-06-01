using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IObjectPool
{
    [SerializeField] float _movePower = 30f;
    [SerializeField] Rigidbody2D _rb;

    void AxeInstantiate()
    {

    }

    bool _isActrive = false;
    public bool IsActive => _isActrive;
    public void DisactiveForInstantiate()
    {

    }
    public void Create()
    {
        transform.position = PlayerManager.Instance.Player.transform.position;

        Vector3 dir = new Vector3(Random.Range(0.5f, -0.5f), Random.Range(1f, -1f), 0).normalized;
        _rb.AddForce(dir * _movePower, ForceMode2D.Impulse);
    }

    public void Destroy()
    {

    }
}
