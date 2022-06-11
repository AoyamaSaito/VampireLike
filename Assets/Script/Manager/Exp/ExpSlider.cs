using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    public void SetValue(int value)
    {
        // アニメーションしながらSliderを動かす
        DOTween.To(() => _slider.value,
            n => _slider.value = n,
            value,
            duration: 1.0f);
    }
}
