using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour, IObjectPool
{
    //ObjectPool
    bool _isActive = false;
    public bool IsActive => _isActive;
    public void DisactiveForInstantiate()
    {
        _isActive = false;
    }
    public void Create()
    {
        _isActive = true;
    }
    public void Destroy()
    {
        _isActive = false;
    }
}
