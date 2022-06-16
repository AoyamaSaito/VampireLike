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
    [SerializeField, Tooltip("“G‚É—^‚¦‚éƒ_ƒ[ƒW")]
    int _power;
    [SerializeField, Tooltip("”­ŽËŠÔŠu")]
    float _interval;
    [SerializeField, Tooltip("ŒÂ”")]
    int _quantity;

    public int Power => _power;
    public float Interval => _interval;
    public int Quantity => _quantity;
}

