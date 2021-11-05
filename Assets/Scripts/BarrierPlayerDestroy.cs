using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPlayerDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthManager health;

        collision.TryGetComponent<HealthManager>(out health);
        if (health != null && health.NameEntity == "Player")
        {
            health.GetDamage(99);
            return;
        }
    }
}
