using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeLiveView : MonoBehaviour
{
    [SerializeField]
    private Text timeLive;
    void Update()
    {
        timeLive.text = "Время жизни: " + TimeLiveManager.time.ToString();
    }
}
