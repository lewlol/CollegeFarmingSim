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
}
