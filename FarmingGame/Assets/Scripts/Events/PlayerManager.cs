using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;

    private void Awake()
    {
        playerManager = this;
    }

    public event Action<CropType, Vector3> OnCropPickup;
    public void CropPickup(CropType ct, Vector3 pos)
    {
        if(OnCropPickup != null)
        {
            OnCropPickup(ct, pos);
        }
    }

    public event Action<int> OnAddCoins;
    public void AddCoins(int amount)
    {
        if (OnAddCoins != null)
        {
            OnAddCoins(amount);
        }
    }

    public event Action<int> OnRemoveCoins;
    public void RemoveCoins(int amount)
    {
        if(OnRemoveCoins != null)
        {
            OnRemoveCoins(amount);
        }
    }

    public event Action<int> OnAddFarmPoints;
    public void AddFarmPoints(int amount)
    {
        if(OnAddFarmPoints != null)
        {
            OnAddFarmPoints(amount);
        }
    }

    public event Action<float> OnFreezePlayer;
    public void FreezePlayer(float time)
    {
        if(OnFreezePlayer != null)
        {
            OnFreezePlayer(time);
        }
    }

    public event Action<ToolType> OnChangeTool;
    public void ChangeTool(ToolType tt)
    {
        if(OnChangeTool != null)
        {
            OnChangeTool(tt);
        }
    }

    public event Action<int> OnAddFarmWorth;
    public void AddFarmWorth(int amount)
    {
        if(OnAddFarmWorth != null)
        {
            OnAddFarmWorth(amount);
        }
    }

    public event Action<int> OnRemoveFarmWorth;
    public void RemoveFarmWorth(int amount)
    {
        if(OnRemoveFarmWorth != null)
        {
            OnRemoveFarmWorth(amount);
        }
    }

    public event Action OnCatchCritter;
    public void CatchCritter()
    {
        if(OnCatchCritter != null)
        {
            OnCatchCritter();
        }
    }

    public event Action OnTillGround;
    public void TillGround()
    {
        if(OnTillGround != null)
        {
            OnTillGround();
        }
    }

    public event Action OnPlantCrop;
    public void PlantCrop()
    {
        if(OnPlantCrop != null)
        {
            OnPlantCrop();
        }
    }

    public event Action OnBuyPlot;
    public void BuyPlot()
    {
        if(OnBuyPlot != null)
        {
            OnBuyPlot();
        }
    }

    public event Action OnAcceptTrade;
    public void AcceptTrade()
    {
        if(OnAcceptTrade != null)
        {
            OnAcceptTrade();
        }
    }
}
