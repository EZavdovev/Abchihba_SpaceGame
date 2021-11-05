using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnEnable()
    {
        damage = PlayerPrefs.GetInt("Damage", damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthManager health;

        collision.TryGetComponent<HealthManager>(out health);
        if (health != null && health.NameEntity == "Enemy")
        {
            health.GetDamage(damage);
            CoinManager.ReceiveCoin(damage);
            PoolManager.putGameObjectToPool(gameObject);
            return;
        }
    }
}
