using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinuteCounter : MonoBehaviour
{
    int minutes;
    float seconds;

    public PlayerStats1 stats;
    private void Update()
    {
        float s = seconds += Time.deltaTime;
        if(s >= 60)
        {
            minutes++;
            seconds = 0;
        }
    }

    public void SetStats()
    {
        stats.minutesPlayed = minutes;
    }
}
