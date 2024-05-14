using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    public TextMeshProUGUI minutes;
    public TextMeshProUGUI worth;

    public PlayerStats1 stats;

    private void Awake()
    {
        worth.text = "You sold your island for " + stats.worth.ToString();
        minutes.text = "You Spent " + stats.minutesPlayed.ToString() + " Minutes Looking after your farm";
    }
}
