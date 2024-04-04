using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    private void Awake()
    {
        uiManager = this;
    }

    public event Action<ToolType> OnToolChange;
    public void ToolChange(ToolType tt)
    {
        if (OnToolChange != null)
        {
            OnToolChange(tt);
        }
    }

    public event Action<int> OnCoinsChanged;
    public void CoinsChanged(int c)
    {
        if(OnCoinsChanged != null)
        { 
            OnCoinsChanged(c); 
        }
    }

    public event Action<int> OnFarmPointsChanged;
    public void FarmPointsChanged(int fp)
    {
        if(OnFarmPointsChanged != null)
        {
            OnFarmPointsChanged(fp);
        }
    }

    public event Action<string, int, int, int> OnOpenVisitorMenu;
    public void OpenVisitorMenu(string cropName, int askAmount, int coinReward, int pointsReward)
    {
        if(OnOpenVisitorMenu != null)
        {
            OnOpenVisitorMenu(cropName, askAmount, coinReward, pointsReward);
        }
    }

    public event Action OnCloseVisitorMenu; 
    public void CloseVisitorMenu()
    {
        if(OnCloseVisitorMenu != null)
        {
            OnCloseVisitorMenu();
        }
    }
}
