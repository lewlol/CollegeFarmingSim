using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterSpawner : MonoBehaviour
{
    [Range(0, 1)]public float critterChance;
    public CritterData[] critters;
    CritterData activeCritter;
    private void Awake()
    {
        PlayerManager.playerManager.OnCropPickup += AttemptCritterSpawn;
    }

    public void AttemptCritterSpawn(CropType ct, Vector3 pos)
    {
        float c = Random.Range(0, 1.001f);
        if (c <= critterChance)
        {
            ChooseCritter(ct);
            SpawnCritter(activeCritter, pos);
        }
    }
    public void ChooseCritter(CropType ct)
    {
        int c = Random.Range(0, critters.Length);
        if (critters[c].critterCrop == ct)
        {
            activeCritter = critters[c];
        }
        else if (critters[c].critterCrop == CropType.All)
        {
            activeCritter = critters[c];
        }
        else
        {
            ChooseCritter(ct);
        }
    }
    public void SpawnCritter(CritterData cd, Vector3 pos)
    {
        Debug.Log("Spawned " + cd.critterName);
    }
}
