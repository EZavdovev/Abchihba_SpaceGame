using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthManager : MonoBehaviour
{
    public static event Action<string> OnChangeHealth = delegate { };
    [SerializeField]
    private int maxHp;
    public int MaxHp
    {
        get
        {
            return maxHp;
        }
    }
    [SerializeField]
    private string nameEntity;
    [SerializeField]
    private float godTime;
    [SerializeField]
    private GameObject EndPopUp;
    public string NameEntity
    {
        get
        {
            return nameEntity;
        }
    }
    [SerializeField]
    private SpriteRenderer spriteEntity;

    private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }
    }
    private bool isGodMode = false;
    private IEnumerator damageCoroutine;

    private void OnEnable()
    {
        if(nameEntity == "Player")
        {
            maxHp = PlayerPrefs.GetInt("MaxHp", maxHp);
        }
        hp = maxHp;
        OnChangeHealth(nameEntity);
    }

    public void GetDamage(int damage)
    {
        if(isGodMode == true)
        {
            return;
        }
        hp -= damage;
        OnChangeHealth(nameEntity);
        if (hp <= 0)
        {
            Die();
            return;
        }

        if (nameEntity == "Player")
        {
            isGodMode = true;
            damageCoroutine = GodTime();
            StartCoroutine(damageCoroutine);
        }
        if (nameEntity == "Enemy")
        {
            damageCoroutine = GetEnemyDamage();
            StartCoroutine(damageCoroutine);
        }
    }

    public void GetHealth(int health)
    {
        hp += health;
        if(hp > maxHp)
        {
            hp = maxHp;
        }
        OnChangeHealth(nameEntity);
    }

    private void Die()
    {
        if(nameEntity == "Enemy")
        {
            PoolManager.putGameObjectToPool(gameObject);
            return;
        }
        if(EndPopUp != null)
        {
            EndPopUp.SetActive(true);
        }
        PlayerPrefs.Save();
        Time.timeScale = 0f;
    }

    private IEnumerator GodTime()
    {
        float timer = 0;
        while(timer < godTime)
        {
            spriteEntity.color = Color.black;
            yield return new WaitForSeconds(0.25f);
            spriteEntity.color = Color.white;
            yield return new WaitForSeconds(0.25f);
            timer += 0.5f;
            
        }
        isGodMode = false;
    }

    private IEnumerator GetEnemyDamage()
    {
        spriteEntity.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteEntity.color = Color.white;
    }
}
