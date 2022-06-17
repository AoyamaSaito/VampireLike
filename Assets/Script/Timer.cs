using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float _finishTime = 60;

    static float _timer = 0;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Result")
        {
            _timer = 0;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Result")
        {
            _timer += Time.deltaTime;
        }

        text.text = _timer.ToString("F1");

        if(60 < _timer)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
