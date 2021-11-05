using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLiveManager : MonoBehaviour
{
    public static float time;

    private void OnEnable()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
