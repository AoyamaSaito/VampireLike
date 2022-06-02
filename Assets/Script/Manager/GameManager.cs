using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager 
{
    [Tooltip("ポーズ時に呼ばれるイベント")] public event Action OnPause;
    [Tooltip("再開時に呼ばれるイベント")] public event Action OnResume;

    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;

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
