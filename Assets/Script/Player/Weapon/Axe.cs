using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : WeaponBase
{
    [SerializeField] 
    private float _movePower = 30f;

    void OnBecameInvisible()
    {
        base.Destroy();
    }

    public override void OnCreate()
    { 
        transform.position = PlayerManager.Instance.Player.transform.position;

        Vector3 dir = new Vector3(Random.Range(0.5f, -0.5f), Random.Range(0.5f, -0.5f), 0).normalized;
        _rb.AddForce(dir * _movePower, ForceMode2D.Impulse);
    }
}