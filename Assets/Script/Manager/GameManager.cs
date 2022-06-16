using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager 
{
    [Tooltip("�|�[�Y���ɌĂ΂��C�x���g")] public event Action OnPause;
    [Tooltip("�ĊJ���ɌĂ΂��C�x���g")] public event Action OnResume;

    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }

    int _stackLevelup = 0;
    SkillSelect _sklSelect = null;
    static public int Level;

    void Start()
    {
        
    }

    public void Setup()
    {
        //ObjectPool�Ɉˑ����Ă���
    }

    private void Init()
    {

    }

    public void LevelUpSelect(SkillSelectTable table)
    {
        switch (table.Type)
        {
            case SelectType.Skill:
                WeaponThrower.Instance.LevelUp(table.TargetName);
                break;
            case SelectType.Passive:

                break;
        }

        if (_stackLevelup > 0)
        {
            _sklSelect.SelectStartDelay();
            _stackLevelup--;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
