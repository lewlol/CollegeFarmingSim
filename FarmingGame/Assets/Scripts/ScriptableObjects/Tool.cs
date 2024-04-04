using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tool")]
public class Tool : ScriptableObject
{
    [Header("Information")]
    public string toolName;
    public GameObject prefab;
    public ToolType type;

    [Header("General Stats")]
    public int level;

    [Header("Seed Stats")]
    public CropType crop;
    public GameObject cropPlot;
}
