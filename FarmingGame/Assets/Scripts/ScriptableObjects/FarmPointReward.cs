using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Farm Point Reward")]
public class FarmPointReward : ScriptableObject
{
    [Header("Info")]
    public string rewardName;
    public int fpCost;

    [Header("Rewards")]
    public RewardType rewardType;
    public CropType cropUnlock;

    [Header("Background")]
    public bool isUnlocked;

    public enum RewardType
    {
        Crop, Boots, Tool
    }
}
