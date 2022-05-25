using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Tooltip("ポーズ時に呼ばれるイベント")] public event Action OnPause;
    [Tooltip("再開時に呼ばれるイベント")] public event Action OnResume;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
