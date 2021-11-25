using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInGame : MonoBehaviour
{
    public static float timer;

    public static Action TimerIncrease;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimerIncrease?.Invoke();
    }
}
