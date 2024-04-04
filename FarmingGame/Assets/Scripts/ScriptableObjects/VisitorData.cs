using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visitor")]
public class VisitorData : ScriptableObject
{
    [Header("Information")]
    public string visitorName;

    [Header("Visitor Stats")]
    public float generocity;
    public Rarity rarity;
    public int farmPointsUnlocked;

    [Header("Trade Stats")]
    public bool multipleCrops;
    public CropData[] crops;
    public int minTradeAmount;
    public int maxTradeAmount;
}
