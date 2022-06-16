using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParam : MonoBehaviour, IPlayerHit
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        PlayerManager.Instance.SetPlayer(this.gameObject);
    }

    public void PlayerHit(int damage)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetExp(collision);
    }

    private void GetExp(Collider2D collider)
    {
        collider.GetComponent<IGetExp>()?.HitExp();
    }
}
