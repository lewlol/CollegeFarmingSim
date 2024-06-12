using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    //UI State Machine
    public bool canOpenInventory;
    public bool canOpenLaptop;
    public bool canOpenTrade;
    public bool canOpenBoatTrade;
    public bool canOpenSellingMenu;

    private void Awake()
    {
        canOpenInventory = true;
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

    public event Action<float, float, float, float> OnUpdateInventoryUI;
    public void UpdateInventoryUI(float wheat, float pumpkin, float carrot, float potato)
    {
        if(OnUpdateInventoryUI != null)
        {
            OnUpdateInventoryUI(wheat, pumpkin, carrot, potato);
        }
    }

    public event Action<Sprite, Sprite, Sprite, int, int, int, int, int> onBoatUI;
    public void BoatUI(Sprite i1, Sprite i2, Sprite i3, int ask1, int ask2, int ask3, int coins, int points)
    {
        if(onBoatUI != null)
        {
            onBoatUI(i1, i2, i3, ask1, ask2, ask3, coins, points);
        }
    }

    public event Action onCloseBoatUI;
    public void CloseBoatUI()
    {
        if(onCloseBoatUI != null)
        {
            onCloseBoatUI();
        }
    }

    public event Action<int, string> onUnlockTextShow;
    public void UnlockTextShow(int cost, string upgradeName)
    {
        if(onUnlockTextShow != null)
        {
            onUnlockTextShow(cost, upgradeName);
        }
    }

    public event Action onDisableUnlockText;
    public void DisableUnlockText()
    {
        if(onDisableUnlockText != null)
        {
            onDisableUnlockText();
        }
    }

    public event Action<int> onOpenSellingMenu;
    public void OpenSellingMenu(int amount)
    {
        if(onOpenSellingMenu != null)
        {
            onOpenSellingMenu(amount);
        }
    }

    public event Action onCloseSellingMenu;
    public void CloseSellingMenu()
    {
        if(onCloseSellingMenu != null)
        {
            onCloseSellingMenu();
        }
    }

    public event Action<string> OnUpdateTutorial;
    public void UpdateTutorial(string t)
    {
        if(OnUpdateTutorial != null)
        {
            OnUpdateTutorial(t);
        }
    }
}
