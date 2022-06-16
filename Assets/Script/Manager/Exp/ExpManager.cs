using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ExpManager
{ 
    static private ExpManager _instance = new ExpManager();
    static public ExpManager Instance => _instance;
    private ExpManager() { }

    private int[] _levelUpTable = ExpTable.Instance.LevelTable;
    private int _level = 0;
    private int _levelUpExp => _levelUpTable[_level];
    public int LevlUpExp => _levelUpExp;

    public IReadOnlyReactiveProperty<int> CurrentExp => _currentExp;
    private readonly IntReactiveProperty _currentExp = new IntReactiveProperty(0);

    public void GetExp(int exp)
    {
        _currentExp.Value += exp;
        Debug.Log($"Œ»Ý‚ÌŒoŒ±’l@{_currentExp.Value}");
        if(_currentExp.Value >= _levelUpExp)
        {
            LevelUp(_currentExp.Value - _levelUpExp);
        }
    }

    private void LevelUp(int remainder)
    {
        Debug.Log("LevelUp");
        SkillSelect.Instance.SelectStart();
        _currentExp.Value = 0;
        _level++;
        
        GetExp(remainder);
    }

    private void OnDestroy()
    {
        _currentExp.Dispose();
    }
}
