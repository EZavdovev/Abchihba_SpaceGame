using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthManager health;

        collision.TryGetComponent<HealthManager>(out health);
        if (health != null)
        {
            health.GetDamage(99);
            return;
        }
        PoolManager.putGameObjectToPool(collision.gameObject);
    }
}
