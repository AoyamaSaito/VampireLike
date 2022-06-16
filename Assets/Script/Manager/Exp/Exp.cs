using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour, IGetExp, IObjectPool
{
    [SerializeField] int get = 1;
    [SerializeField] SpriteRenderer _image;

    private bool _isActive = false;
    public bool IsActive => _isActive;

    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        _isActive = false;
    }

    public void Create()
    {
        _image.enabled = true;
        _isActive = true;
    }

    public void Destroy()
    {
        _image.enabled = false;
        _isActive = false;
    }

    public void HitExp()
    {
        ExpManager.Instance.GetExp(get);
        Destroy(gameObject);
    }
}
