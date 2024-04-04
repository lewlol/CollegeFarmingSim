using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tool")]
public class Tool : ScriptableObject
{
    public int level;
    public GameObject prefab;
    public ToolType type;
}
