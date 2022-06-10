using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WeaponThrower : MonoBehaviour
{
    [SerializeField] List<WeaponBase> _weaponBases;
    [SerializeField] Transform _root;

    List<ObjectPool<WeaponBase>> _weaponPool = new List<ObjectPool<WeaponBase>>();
    public List<ObjectPool<WeaponBase>> WeaponPool => _weaponPool;

    private void Start()
    {
        Throw();
    }

    private void Throw()
    {
        for(int i = 0; i < _weaponBases.Count; ++i)
        {
            ObjectPool<WeaponBase> weaponPool = new ObjectPool<WeaponBase>();
            foreach(var weapon in _weaponBases)
            {
                Debug.Log(weaponPool);
                Debug.Log(weapon);
                Debug.Log(weapon.Quantity);
                Debug.Log(weapon.Interval);
                weaponPool.SetBaseObj(weapon, _root);
                weaponPool.SetCapacity(weapon.Quantity);

                StartCoroutine(ThrowTimer(weapon, weaponPool));
            }
        }
    }

    IEnumerator ThrowTimer(WeaponBase weapon, ObjectPool<WeaponBase> weaponPool, bool n = false)
    {
        while (n!)
        {
            float _interval = weapon.Interval;
            yield return new WaitForSeconds(_interval);
            for (int i = 0; i < weapon.Quantity; ++i)
            {
                weaponPool.Instantiate();
            }
        }
    }

    public void StopThrow()
    {
        foreach (var weaponPool in _weaponPool)
        {
            foreach (var weapon in _weaponBases)
            {
                StopCoroutine(ThrowTimer(weapon, weaponPool));
            }
        }
    }

    public void AddWeapon(WeaponBase weapon)
    {
        _weaponBases.Add(weapon);
        StopThrow();
        Throw();
    }

}
