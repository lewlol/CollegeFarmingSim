using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int wheat;
    public int pumpkin;
    public int potato;
    public int carrot;

    private void Start()
    {
        PlayerManager.playerManager.OnCropPickup += AddCrops;
    }
    public void AddCrops(CropType ct)
    {
        switch (ct) 
        {
            case CropType.Wheat:
                wheat++;
                break;
            case CropType.Pumpkin:
                pumpkin++;
                break;
            case CropType.Potato:
                potato++;
                break;
            case CropType.Carrot:
                carrot++;
                break;
        }
    }
}
