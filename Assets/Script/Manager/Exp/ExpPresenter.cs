using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ExpPresenter : MonoBehaviour
{
    [SerializeField]
    private ExpSlider _expSlider;

    private ExpManager _expManager;

    private void Start()
    {
        _expManager = ExpManager.Instance;

        _expManager.CurrentExp
                .Subscribe(x =>
                {
                    // View�ɔ��f
                    _expSlider.SetValue(x / _expManager.LevlUpExp);
                }).AddTo(this);
    }
}
