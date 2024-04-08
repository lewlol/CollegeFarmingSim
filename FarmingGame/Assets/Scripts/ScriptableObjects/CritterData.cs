using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Critter")]
public class CritterData : ScriptableObject
{
    [Header("Critter Info")]
    public string critterName;
    public string critterDescription;
    public GameObject critterPrefab;

    [Header("Critter Stats / Spawning Req")]
    public float critterSpeed;
    public AIType critterAI;
    public CropType critterCrop;
}
