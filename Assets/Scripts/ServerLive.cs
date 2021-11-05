using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerLive : MonoBehaviour
{
    [SerializeField]
    private Text viewResult;
    private float maxResult;

    private void OnEnable()
    {
        maxResult = Mathf.Max(PlayerPrefs.GetFloat("PlayerResult", TimeLiveManager.time + Random.Range(1f, 2f)), TimeLiveManager.time + Random.Range(1f, 2f));
        viewResult.text = "Лучший результат среди всех игроков: " + maxResult;
        PlayerPrefs.SetFloat("PlayerResult", maxResult);
        PlayerPrefs.Save();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("PlayerResult", maxResult);
        PlayerPrefs.Save();
    }
}
