using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoMenuUI : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI farmPointCount;

    private void Start()
    {
        UIManager.uiManager.OnCoinsChanged += ChangeCoins;
        UIManager.uiManager.OnFarmPointsChanged += ChangeFarmPoints;
    }
    public void ChangeCoins(int newAmount)
    {
        coinCount.text = newAmount.ToString();
    }

    public void ChangeFarmPoints(int newAmount)
    {
        farmPointCount.text = newAmount.ToString();
    }
}
