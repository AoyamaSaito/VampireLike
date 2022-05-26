using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    [SerializeField] GameObject _player;

    public GameObject Player => _player;

    public Vector3 ReturnPlayerDirection(Vector3 vec)
    {
        return _player.transform.position - vec;
    }
}
