using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEvent : MonoBehaviour
{
    public static TickEvent tickEvent;
    private void Start()
    {
        tickEvent = this;
    }
    public event Action OnTick;
    public void Tick()
    {
        if (OnTick != null) //Used for Crop Growth (Chance per Tick)
        {
            OnTick();
        }
    }
}
