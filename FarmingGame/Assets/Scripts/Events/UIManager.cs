using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    //UI State Machine
    public bool canOpenInventory;
    public bool canOpenLaptop;
    public bool canOpenTrade;

    private void Awake()
    {
        uiManager = this;
    }

    public event Action<ToolType, string> OnToolChange;
    public void ToolChange(ToolType tt, string cropName)
    {
        if (OnToolChange != null)
        {
            OnToolChange(tt, cropName);
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

    public event Action<string, int, int, int, Sprite> OnOpenVisitorMenu;
    public void OpenVisitorMenu(string cropName, int askAmount, int coinReward, int pointsReward, Sprite cropImage)
    {
        if(OnOpenVisitorMenu != null)
        {
            OnOpenVisitorMenu(cropName, askAmount, coinReward, pointsReward, cropImage);
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

    public event Action<float, float, float> OnUpdateInventoryUI;
    public void UpdateInventoryUI(float wheat, float pumpkin, float carrot)
    {
        if(OnUpdateInventoryUI != null)
        {
            OnUpdateInventoryUI(wheat, pumpkin, carrot);
        }
    }
}
