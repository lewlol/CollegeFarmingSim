using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpot : MonoBehaviour
{
    [Range(0, 1)] public float carrotChance;

    public GameObject smallCarrot;
    public GameObject largeCarrot;

    bool isBig;
    public void Awake()
    {
        TickManager.tickManager.OnTickEvent += GrowCarrot;
    }

    public void GrowCarrot()
    {
        float cc = Random.Range(0, 1.0001f);
        if (cc <= carrotChance) 
        { 
            smallCarrot.SetActive(false);
            largeCarrot.SetActive(true);

            TickManager.tickManager.OnTickEvent -= GrowCarrot;

            isBig = true;
        }
    }

    public void CarrotPickedUp()
    {
        smallCarrot.SetActive(true);
        largeCarrot.SetActive(false);

        TickManager.tickManager.OnTickEvent += GrowCarrot;

        isBig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isBig)
            {
                CarrotPickedUp();
                PlayerManager.playerManager.CropPickup(CropType.Carrot);
            }
        }
    }
}
