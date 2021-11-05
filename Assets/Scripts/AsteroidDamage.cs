using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthManager health;

        collision.TryGetComponent<HealthManager>(out health);
        if (health != null && health.NameEntity == "Player")
        {
            health.GetDamage(damage);
            gameObject.GetComponent<HealthManager>().GetDamage(99);
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthManager health;

        collision.TryGetComponent<HealthManager>(out health);
        if (health != null && health.NameEntity == "Player")
        {
            health.GetDamage(damage);
            gameObject.GetComponent<HealthManager>().GetDamage(99);
            return;
        }
    }
}
