using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    public static TickManager tickManager;
    private void Awake()
    {
        tickManager = this;
    }
    public event Action OnTickEvent;
    public void TickEvent()
    {
        if (OnTickEvent != null)
        {
            OnTickEvent();
        }
    }
}
