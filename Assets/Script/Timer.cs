using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float _finishTime = 180;

    float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;

        text.text = _timer.ToString("D1");

        if(_finishTime < _timer)
        {

        }
    }
}
