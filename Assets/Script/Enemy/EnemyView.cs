using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private SpriteRenderer _image;
    private PoolEnemy _poolEnemy;

    private void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _poolEnemy = GetComponent<PoolEnemy>();
        _poolEnemy?.ObserveEveryValueChanged(_poolEnemy => _poolEnemy.IsActive)
            .Subscribe(value => _image.enabled = value!);
    }
}