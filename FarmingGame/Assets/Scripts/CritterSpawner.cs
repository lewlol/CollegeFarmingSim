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
        activeCritter = critters[c];
    }
    public void SpawnCritter(CritterData cd, Vector3 pos)
    {
        Instantiate(cd.critterPrefab, pos, Quaternion.identity);
        PlayerManager.playerManager.RemoveFarmWorth(5);
    }
}
