using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WeaponThrower : MonoBehaviour
{
    [SerializeField] List<WeaponBase> _weaponBases;

    float _timer = 0;

    private void Start()
    {
        ThrowStart();

        _weaponBases.ObserveEveryValueChanged(_weaponBases => _weaponBases.Count)
            .Subscribe(_ => ThrowStart());
    }

    private void ThrowStart()
    {
        foreach(var weapon in _weaponBases)
        {
            StartCoroutine(ThrowTimer(weapon));
        }
    }

    public void Throw()
    {
        for(int i = 0; i < _weaponBases.Count; ++i)
        {
            for(int j = 0; j < _weaponBases[i].Quantity; ++i)
            {
                _weaponBases[i].Create();
            }
        }
    }

    IEnumerator ThrowTimer(WeaponBase _weapon)
    {
        bool n = false;
        while (n!)
        {
            for (int i = 0; i < _weaponBases.Count; ++i)
            {
                float _interval = _weapon.Interval;
                yield return new WaitForSeconds(_interval);
                for (int j = 0; j < _weaponBases[i].Quantity; ++i)
                {
                    _weaponBases[i].Create();
                }
            }
            
        }
    }
}
