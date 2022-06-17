using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    [SerializeField] Text _text;

    static int enemyCount = 0;

    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Result")
        {
            enemyCount = 0;
        }
    }

    public void Set(int a)
    {
        enemyCount = a;
    }

    // Update is called once per frame
    void Update()
    {
        if(_text) _text.text = enemyCount.ToString();
    }
}
