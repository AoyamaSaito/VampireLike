using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateWeponParamAsset")]
public class WeaponData : ScriptableObject
{
    [SerializeField] Weapon[] _wepon;

    public Weapon[] Wepon => _wepon;
}

[Serializable]
public class Weapon
{
    [SerializeField, Tooltip("�G�ɗ^����_���[�W")]
    int _power;
    [SerializeField, Tooltip("���ˊԊu")]
    float _interval;
    [SerializeField, Tooltip("��")]
    int _quantity;

    public int Power => _power;
    public float Interval => _interval;
    public int Quantity => _quantity;
}

