using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPopUp;
    public void Try()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Shop()
    {
        shopPopUp.SetActive(true);
        gameObject.SetActive(false);
    }
}
