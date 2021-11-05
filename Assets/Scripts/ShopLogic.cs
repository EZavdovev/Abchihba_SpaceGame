using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopLogic : MonoBehaviour
{
    public void Try()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Damage()
    {
        if(CoinManager.GetCoin() >= 50)
        {
            CoinManager.LessCoin(50);
            int damage = PlayerPrefs.GetInt("Damage", 1) + 1;
            PlayerPrefs.SetInt("Damage", damage);
            PlayerPrefs.Save();
        }
    }

    public void Health()
    {
        if(CoinManager.GetCoin() >= 45)
        {
            CoinManager.LessCoin(45);
            int health = PlayerPrefs.GetInt("MaxHp", 3) + 1;
            PlayerPrefs.SetInt("MaxHp", health);
            PlayerPrefs.Save();
        }
    }

}
