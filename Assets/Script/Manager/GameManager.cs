using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Tooltip("�|�[�Y���ɌĂ΂��C�x���g")] public event Action OnPause;
    [Tooltip("�ĊJ���ɌĂ΂��C�x���g")] public event Action OnResume;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
