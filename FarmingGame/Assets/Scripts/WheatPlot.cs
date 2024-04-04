using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatPlot : MonoBehaviour
{
    [Range(0, 1)] public float wheatChance;

    public GameObject smallWheat;
    public GameObject largeWheat;
    private void Awake()
    {
        TickEvent.tickEvent.OnTick += GrowWheat;   
    }
    public void GrowWheat()
    {
        //Attempt the Growth
        float wc = Random.Range(0, 1);
        if(wc <= wheatChance)
        {
            //Disable Small Wheat 
            smallWheat.SetActive(false);

            //Enable Big Wheat
            largeWheat.SetActive(true);

        }
    }

    public void WheatPickedUp()
    {
        //Disable Big Wheat
        largeWheat.SetActive(false);

        //Enable Small Wheat
        smallWheat.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            WheatPickedUp();
        }
    }
}
