using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam : MonoBehaviour, IWeaponHit
{
    [SerializeField] float _damage = 0.05f;
    [SerializeField] GameObject _exp;
    public event Action OnDamage;
    public event Action OnDeath;

    int _hp = 10;
    int _power = 1;
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
            Spawner.Instance.Count++;
            _poolEnemy.Destroy();
            Instantiate(_exp, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(_poolEnemy.IsActive)
        {
            collision.gameObject.GetComponent<IPlayerHit>()?.PlayerHit(_damage);
        }
    }
}
