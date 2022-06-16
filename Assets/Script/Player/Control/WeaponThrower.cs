using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class WeaponThrower : SingletonMonoBehaviour<WeaponThrower>
{
    [SerializeField] WeaponBase _weapon;
    [SerializeField] Transform _root;

    ObjectPool<WeaponBase> _weaponPool = new ObjectPool<WeaponBase>();
    public ObjectPool<WeaponBase> WeaponPool => _weaponPool;
    private IEnumerator _coroutine;

    private void Start()
    {
        _weapon.Init();
        Throw();
    }

    private void Throw()
    {
        _weaponPool.SetBaseObj(_weapon, _root);
        _weaponPool.SetCapacity(20);

        _coroutine = ThrowTimer(_weapon, _weaponPool);
        StartCoroutine(_coroutine);
    }

    IEnumerator ThrowTimer(WeaponBase weapon, ObjectPool<WeaponBase> weaponPool)
    {
        bool n = true;
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
        StopCoroutine(_coroutine);
    }

    public void LevelUp(string name)
    {
        StopThrow();
        _weapon.LevelUp();
        Throw();
    }
}
