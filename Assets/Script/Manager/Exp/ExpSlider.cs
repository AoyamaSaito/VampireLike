using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    public void SetValue(float value)
    {
        Debug.Log($"割合{value}");
        // アニメーションしながらSliderを動かす
        DOTween.To(() => _slider.value,
            n => _slider.value = n,
            value,
            duration: 1.0f);
    }
}
