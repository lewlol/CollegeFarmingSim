using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int wheat;
    public int pumpkin;
    public int potato;
    public int carrot;


    //Fortune
    int fortuneBonus;
    private void Start()
    {
        PlayerManager.playerManager.OnCropPickup += AddCrops;
    }
    public void AddCrops(CropType ct)
    {
        //Every 100 Fortune = +1 Drop Confirmed
        int fortune = PlayerStats.playerStats.farmingFortune;
        if(fortune >= 100)
        {
            float newFortune = fortune / 100;
            fortuneBonus = Mathf.RoundToInt(newFortune);
        }

        //1 - 99 Chance for an extra drop
        ExtraFortuneBonus(fortune);
        Debug.Log(fortuneBonus);

        switch (ct) 
        {
            case CropType.Wheat:
                wheat +=  1 + fortuneBonus;
                break;
            case CropType.Pumpkin:
                pumpkin += 1 + fortuneBonus;
                break;
            case CropType.Potato:
                potato += 1 + fortuneBonus;
                break;
            case CropType.Carrot:
                carrot += 1 + fortuneBonus;
                break;
        }

        fortuneBonus = 0;
    }

    private void ExtraFortuneBonus(int fortune)
    {
        if(fortune >= 100)
        {
            int newfortune = fortune - 100;
            ExtraFortuneBonus(newfortune);
        }
        else
        {
            int r = Random.Range(0, 100);
            if(r <= fortune)
            {
                fortuneBonus += 1;
                return;
            }
        }
    }
}
