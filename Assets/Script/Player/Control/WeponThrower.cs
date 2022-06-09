using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : MonoBehaviour
{
    [SerializeField] List<WeaponBase> _weaponBases;

    float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;

    }

    public void Throw()
    {
        for(int i = 0; i < _weaponBases.Count; ++i)
        {
            for(int j = 0; j < _weaponBases[i].Quantity; ++i)
            {
                _weaponBases[i].Create();
            }
        }
    }

    //IEnumerator Timer(int index)
    //{
    //    bool i = false;
    //    while (i)
    //    {
            
    //    }
    //}
}
