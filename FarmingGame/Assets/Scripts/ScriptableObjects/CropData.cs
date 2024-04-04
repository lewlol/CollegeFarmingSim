using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crop")]
public class CropData : ScriptableObject
{
    public string cropName;
    public CropType cropType;
    public int cropPrice;
    public int cropPoints;
}
