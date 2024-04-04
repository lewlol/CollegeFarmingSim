using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticks : MonoBehaviour
{
    public float tickSpeed;
    float c;

    private void Start()
    {
        c = tickSpeed;
    }

    private void Update()
    {
        float countDown = c -= Time.deltaTime;
        if (countDown <= 0) 
        {
            //Tick Happened
            TickManager.tickManager.TickEvent();
            c = tickSpeed;
        }
    }
}
