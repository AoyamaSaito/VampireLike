using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateWeponParamAsset")]
public class WeaponData : ScriptableObject, ILevel
{
    [SerializeField] Weapon[] _wepon;

    int _level = 0;

    public int Level => _level;
    public Weapon Wepon => _wepon[_level];

    public void LevelUp()
    {
        _level++;
    }
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

