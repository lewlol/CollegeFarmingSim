using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpot : MonoBehaviour
{
    [Range(0, 1)] public float wheatChance;

    public GameObject smallWheat;
    public GameObject largeWheat;

    bool isBig;
    public void Awake()
    {
        TickManager.tickManager.OnTickEvent += GrowWheat;
    }
    public void GrowWheat()
    {
        //Attempt the Growth
        float wc = Random.Range(0, 1.001f);
        if(wc <= wheatChance)
        {
            //Disable Small Wheat 
            smallWheat.SetActive(false);

            //Enable Big Wheat
            largeWheat.SetActive(true);

            TickManager.tickManager.OnTickEvent -= GrowWheat;

            isBig = true;
        }
    }

    public void WheatPickedUp()
    {
        //Disable Big Wheat
        largeWheat.SetActive(false);

        //Enable Small Wheat
        smallWheat.SetActive(true);

        TickManager.tickManager.OnTickEvent += GrowWheat;

        isBig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isBig)
            {
                WheatPickedUp();
                PlayerManager.playerManager.CropPickup(CropType.Wheat);
            }
        }
    }
}
