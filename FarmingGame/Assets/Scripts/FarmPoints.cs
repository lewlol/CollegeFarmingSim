using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPoints : MonoBehaviour
{
    public int farmPoints;

    private void Start()
    {
        PlayerManager.playerManager.OnAddFarmPoints += AddFarmPoints;
    }
    public void AddFarmPoints(int f)
    {
        farmPoints += f;
        UIManager.uiManager.FarmPointsChanged(farmPoints);
    }
}
