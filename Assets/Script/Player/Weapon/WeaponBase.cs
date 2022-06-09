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
    private WeaponData _weponData;

    protected int _power = 0;
    public int Power => _power;
    protected float _interval = 0;
    public float Interval => _interval;
    protected int _quantity = 0;
    public int Quantity => _quantity;
    private Weapon _weapon;

    private bool _isActrive = false;
    public bool IsActive => _isActrive;

    abstract public void OnCreate();

    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }

    public void Create()
    {
        _image.enabled = true;
        _rb.simulated = true;

        _weapon = _weponData.Wepon;
        SetParamator(_weapon.Power, _weapon.Interval, _weapon.Quantity);

        OnCreate();
    }

    public void Destroy()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }

    private void SetParamator(int power, float interval, int quantity)
    {
        _power = power;
        _interval = interval;
        _quantity = quantity;
    }
}
