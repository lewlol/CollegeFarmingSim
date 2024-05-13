using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FarmPointUpgradeUI : MonoBehaviour
{
    public FarmPointReward upgrade;

    //UI
    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI upgradeCost;

    private void Awake()
    {
        //Set the UI here
        upgradeName.text = "  " + upgrade.rewardName;
        upgradeCost.text = upgrade.fpCost.ToString();
    }

    public void Buy()
    {
        //Set Rewards Here.
        switch (upgrade.rewardType) 
        { 
            case FarmPointReward.RewardType.Crop:
                CropUpgrade(upgrade.cropUnlock);
                break;
        }
    }

    private void CropUpgrade(CropType crop)
    {
        switch (crop)
        {
            case CropType.Pumpkin:
                break;
            case CropType.Carrot:
                break;
            case CropType.Potato:
                break;
        }
    }
}
