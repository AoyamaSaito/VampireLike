using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam : MonoBehaviour, IWeaponHit
{
    [SerializeField] GameObject _exp;
    public event Action OnDamage;
    public event Action OnDeath;

    int _hp = 10;
    int _power = 1;
    //GameObject _expObject = null;
    PoolEnemy _poolEnemy;

    private void Start()
    {
        _poolEnemy = GetComponent<PoolEnemy>();
    }

    public void WeaponHit(int damage)
    {
        _hp -= damage;
        OnDamage();

        if(_hp <= 0)
        {
            Instantiate(_exp, transform.position, Quaternion.identity);
            _poolEnemy.Destroy();
        }
    }
}
