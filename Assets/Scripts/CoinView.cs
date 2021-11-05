using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField]
    private Text coin;
    private void OnEnable()
    {
        ChangeView();
        CoinManager.OnChangeCoin += ChangeView;
    }

    private void OnDisable()
    {
        CoinManager.OnChangeCoin -= ChangeView;
    }

    private void ChangeView()
    {
        coin.text = "Монет: " + CoinManager.GetCoin();
    }
}
