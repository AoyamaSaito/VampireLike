using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    [SerializeField]
    public Slider _slider;

    public void SetValue(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        _slider.value = value;
    }
}
