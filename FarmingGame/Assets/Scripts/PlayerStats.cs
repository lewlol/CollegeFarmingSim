using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    [Header("Player Stats")]
    public float speed;
    public int farmingFortune;

    private void Awake()
    {
        playerStats = this;
    }
}
