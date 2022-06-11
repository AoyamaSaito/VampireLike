using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IObjectPool
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

    private int _power;
    public int Power => _weaponData.Wepon.Power;
    private float _interval;
    public float Interval => _weaponData.Wepon.Interval;
    private int _quantity;
    public int Quantity => _weaponData.Wepon.Quantity;

    private void Awake()
    {
        SetParamator(_weaponData);
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
        Debug.Log(weaponData.Wepon.Power);
        Debug.Log(weaponData.Wepon.Interval);
        Debug.Log(weaponData.Wepon.Quantity);

        _power = weaponData.Wepon.Power;
        _interval = weaponData.Wepon.Interval;
        _quantity = weaponData.Wepon.Quantity;
    }
}
