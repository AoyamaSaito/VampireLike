using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IObjectPool, ILevel
{
    //[SerializeField]
    //private float _movePower = 30f;
    [Header("�Ƃ肠�����Q�Ƃ��������")]
    [SerializeField]
    protected Rigidbody2D _rb;
    [SerializeField]
    private SpriteRenderer _image;
    [Header("�f�[�^")]
    [SerializeField]
    private WeaponData _weaponData;
    public WeaponData WeaponData => _weaponData;

    private int _level = 0;
    //public int Level => _level;
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
        Debug.Log(weaponData.Wepon[_level].Power);
        Debug.Log(weaponData.Wepon[_level].Interval);
        Debug.Log(weaponData.Wepon[_level].Quantity);

        _power = weaponData.Wepon[_level].Power;
        _interval = weaponData.Wepon[_level].Interval;
        _quantity = weaponData.Wepon[_level].Quantity;
    }

    public void LevelUp()
    {
        _level++;
    }
}
