using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class WeaponThrower : SingletonMonoBehaviour<WeaponThrower>
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
                weaponPool.SetBaseObj(weapon, _root);
                weaponPool.SetCapacity(10);

                StartCoroutine(ThrowTimer(weapon, weaponPool));
            }
        }
    }

    IEnumerator ThrowTimer(WeaponBase weapon, ObjectPool<WeaponBase> weaponPool)
    {
        bool n = true;
        Debug.Log("Throw�J�n");
        while (n!)
        {
            float _interval = weapon.Interval;
            Debug.Log("�ҋ@");
            yield return new WaitForSeconds(_interval);
            Debug.Log("Throw");
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

    public void LevelUp(string name)
    {
        foreach(var weapon in _weaponBases.Where(s => s.name == name))
        {
            weapon.LevelUp();
        }
    }
}
