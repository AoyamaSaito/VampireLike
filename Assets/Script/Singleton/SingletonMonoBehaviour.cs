using UnityEngine;
using System;

/// <summary>継承するとシングルトンパターンになる</summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    //カプセル化
    public static T Instance => instance;

    virtual protected void Awake()
    {
        CheckInstance();
    }

    /// <summary>インスタンスがなければ代入する、すでにあればなにもしない</summary>
    /// <returns></returns>
    protected void CheckInstance()
    {
        if (instance == null)
        {
            instance = this as T; //instanceがnullならば代入
        }
        else if (Instance == this)
        {
            return;　//同じならなにもしない
        }
        else if(Instance != this)
        {
            Destroy(this);　//すでにあればなにもせず消える
        }
    }
}