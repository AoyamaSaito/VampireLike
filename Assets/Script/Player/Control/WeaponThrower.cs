using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WeaponThrower : SingletonMonoBehaviour<WeaponThrower>
{
    [SerializeField] WeaponBase _weapon;
    [SerializeField] Transform _root;
    [SerializeField] Text _go;
    [SerializeField] Collider2D _col;
    [SerializeField] Slider _slider;

    ObjectPool<WeaponBase> _weaponPool = new ObjectPool<WeaponBase>();
    public ObjectPool<WeaponBase> WeaponPool => _weaponPool;
    private IEnumerator _coroutine;
    ExpManager _expManager;
    ContactFilter2D colf;
    Collider2D[] cols = new Collider2D[30];

    private void Start()
    {
        _expManager = ExpManager.Instance;
        _weapon.Init();
        Throw();
    }

    private void Update()
    {
        //bool b = _expManager.Judge();
        //Debug.Log(b);
        if (_slider.value >= 0.5)
        {
            _go.enabled = true;
            if (Input.GetButtonDown("Jump"))
            {
                _expManager.Reset();
                _col.OverlapCollider(colf, cols);
                foreach(var i in cols)
                {
                    i.GetComponent<EnemyParam>()?.WeaponHit(99);
                }
            }
        }
        else
        {
            _go.enabled = false;
        }
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
