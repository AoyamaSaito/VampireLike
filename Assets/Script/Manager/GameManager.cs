using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Tooltip("�|�[�Y���ɌĂ΂��C�x���g")] public event Action OnPause;
    [Tooltip("�ĊJ���ɌĂ΂��C�x���g")] public event Action OnResume;

    List<PoolEnemy> _enemies = new List<PoolEnemy>();

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
