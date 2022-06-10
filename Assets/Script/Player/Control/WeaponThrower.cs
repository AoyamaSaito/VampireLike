using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WeaponThrower : MonoBehaviour
{
    [SerializeField] List<WeaponBase> _weaponBases;

    private void Start()
    {
        Throw();
    }

    private void Throw()
    {
        foreach(var weapon in _weaponBases)
        {
            StartCoroutine(ThrowTimer(weapon));
        }
    }

    IEnumerator ThrowTimer(WeaponBase _weapon, bool n = false)
    {
        while (n!)
        {
            float _interval = _weapon.Interval;
            yield return new WaitForSeconds(_interval);
            for (int i = 0; i < _weapon.Quantity; ++i)
            {
                _weapon.Create();
            }
        }
    }

    public void StopThrow()
    {
        foreach (var weapon in _weaponBases)
        {
            StopCoroutine(ThrowTimer(weapon));
        }
    }

    public void AddWeapon(WeaponBase weapon)
    {
        _weaponBases.Add(weapon);
        StopThrow();
        Throw();
    }

}
