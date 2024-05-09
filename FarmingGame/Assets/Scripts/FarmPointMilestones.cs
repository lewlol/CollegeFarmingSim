using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPointMilestones : MonoBehaviour
{
    public FarmPointReward[] rewards;
    public int currentReward;
    private void Start()
    {
        PlayerManager.playerManager.OnAddFarmPoints += UnlockRewards;
    }
    public void UnlockRewards(int fpAmount)
    {
        if(fpAmount >= rewards[currentReward].fpRequired)
        {
            //Apply Rewards
            PlayerManager.playerManager.AddCoins(rewards[currentReward].coinReward);
            //Next Reward
            currentReward++;
        }
    }
}
