using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParam : MonoBehaviour, IWeaponHit
{
    public event Action OnDamage;
    public event Action OnDeath;

    int _hp = 0;
    int _power = 0;
    GameObject _expObject = null;

    public void WeaponHit(int damage)
    {
        _hp -= damage;
        OnDamage();

        if(_hp <= 0)
        {
            OnDeath();
        }
    }
}
