using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoMenuUI : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI farmPointCount;

    public TextMeshProUGUI unlockText;

    private void Start()
    {
        UIManager.uiManager.OnCoinsChanged += ChangeCoins;
        UIManager.uiManager.OnFarmPointsChanged += ChangeFarmPoints;

        UIManager.uiManager.onUnlockTextShow += UnlockText;
        UIManager.uiManager.onDisableUnlockText += DisableUnlockText;
    }
    public void ChangeCoins(int newAmount)
    {
        coinCount.text = newAmount.ToString();
    }

    public void ChangeFarmPoints(int newAmount)
    {
        farmPointCount.text = newAmount.ToString();
    }

    public void UnlockText(int cost, string upgradeName)
    {
        unlockText.enabled = true;

        string c = cost.ToString();
        unlockText.text = "Press E to Unlock " + upgradeName + " for " + cost;
    }

    public void DisableUnlockText()
    {
        unlockText.enabled = false;
    }
}
