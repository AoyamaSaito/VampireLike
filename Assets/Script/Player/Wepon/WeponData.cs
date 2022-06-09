using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateWeponParamAsset")]
public class WeponData : ScriptableObject
{
    [SerializeField] Wepon[] _wepon;

    int _level = 0;
    public Wepon Wepon => _wepon[_level];

    public void LevelUp()
    {
        _level++;
    }
}

[Serializable]
public class Wepon
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

