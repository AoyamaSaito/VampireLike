using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IObjectPool, ILevel
{
    //[SerializeField]
    //private float _movePower = 30f;
    [Header("とりあえず参照したいやつ")]
    [SerializeField]
    protected Rigidbody2D _rb;
    [SerializeField]
    private SpriteRenderer _image;
    [Header("データ")]
    [SerializeField]
    private WeaponData _weaponData;
    public WeaponData WeaponData => _weaponData;

    private int _level = 0;
    private int _power;
    public int Power => _weaponData.Wepon[_level].Power;
    private float _interval;
    public float Interval => _weaponData.Wepon[_level].Interval;
    private int _quantity;
    public int Quantity => _weaponData.Wepon[_level].Quantity;

    private void Awake()
    {
        SetParamator(_weaponData);
    }

    public void Init()
    {
        _level = 0;
    }

    virtual public void OnStart() { }

    private bool _isActrive = false;
    public bool IsActive => _isActrive;

    abstract public void OnCreate();

    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        _rb.simulated = false;
        _isActrive = false;
    }

    public void Create()
    {
        _image.enabled = true;
        _rb.simulated = true;
        _isActrive = true;

        SetParamator(_weaponData);

        OnCreate();
    }

    public void Destroy()
    {
        _image.enabled = false;
        _rb.simulated = false;
        _isActrive = false;
    }

    private void SetParamator(WeaponData weaponData)
    {
        _power = weaponData.Wepon[_level].Power;
        _interval = weaponData.Wepon[_level].Interval;
        _quantity = weaponData.Wepon[_level].Quantity;
    }

    public void LevelUp()
    {
        _level++;
    }
}
