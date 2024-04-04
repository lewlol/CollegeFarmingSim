using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpot : MonoBehaviour
{
    [Range(0, 1)] public float pumpkinChance;

    public GameObject smallPumpkin;
    public GameObject largePumpkin;

    bool isBig;

    private void Awake()
    {
        TickManager.tickManager.OnTickEvent += GrowPumpkin;
    }

    public void GrowPumpkin()
    {
        float pc = Random.Range(0, 1.001f);
        if( pc <= pumpkinChance)
        {
            smallPumpkin.SetActive(false);
            largePumpkin.SetActive(true);
            TickManager.tickManager.OnTickEvent -= GrowPumpkin;
            isBig = true;
        }
    }

    public void PumpkinPickup()
    {
        smallPumpkin.SetActive(true);
        largePumpkin.SetActive(false);
        TickManager.tickManager.OnTickEvent += GrowPumpkin;
        isBig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isBig)
            {
                PumpkinPickup();
                PlayerManager.playerManager.CropPickup(CropType.Pumpkin);
            }
        }
    }
}
