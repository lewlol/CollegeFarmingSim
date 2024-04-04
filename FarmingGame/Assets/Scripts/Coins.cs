using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coins;

    private void Start()
    {
        PlayerManager.playerManager.OnAddCoins += AddCoins;
        PlayerManager.playerManager.OnRemoveCoins += RemoveCoins;
    }
    public void AddCoins(int c)
    {
        coins += c;
        UIManager.uiManager.CoinsChanged(coins);
    }

    public void RemoveCoins(int c)
    {
        coins -= c;
        UIManager.uiManager.CoinsChanged(coins);
    }
}
