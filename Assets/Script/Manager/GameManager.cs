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
    // Update is called once per frame
    void Update()
    {
        
    }
}
