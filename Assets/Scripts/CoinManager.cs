using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static event Action OnChangeCoin = delegate { };
    private static int coin;

    private void OnEnable()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        OnChangeCoin();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }

    public static int GetCoin()
    {
        return coin;
    }

    public static void ReceiveCoin(int c)
    {
        coin += c;
        OnChangeCoin();
    }

    public static void LessCoin(int c)
    {
        coin -= c;
        OnChangeCoin();
    }
}
