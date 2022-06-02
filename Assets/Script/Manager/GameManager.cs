using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Tooltip("ポーズ時に呼ばれるイベント")] public event Action OnPause;
    [Tooltip("再開時に呼ばれるイベント")] public event Action OnResume;

    List<PoolEnemy> _enemies = new List<PoolEnemy>();

    void Start()
    {
        
    }

    public void Setup()
    {
        //ObjectPoolに依存している
    }

    private void Init()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
