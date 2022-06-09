using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Hit(collision);
    }

    private void Hit(Collider2D col)
    {
        col.gameObject.TryGetComponent<IPlayerHit>(out IPlayerHit hittable);
        hittable?.PlayerHit(1);
    }
}
