using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotatoSpot : MonoBehaviour
{
    [Range(0, 1)] public float potatoChance;
    public GameObject smallPotato;
    public GameObject largePotato;

    bool isBig;

    private void Awake()
    {
        TickManager.tickManager.OnTickEvent += GrowPotato;
    }

    public void GrowPotato()
    {
        float pc = Random.Range(0, 1.001f);
        if(pc <= potatoChance)
        {
            smallPotato.SetActive(false);
            largePotato.SetActive(true);
            TickManager.tickManager.OnTickEvent -= GrowPotato;
            isBig = true;
        }
    }

    public void PotatoPickup()
    {
        smallPotato.SetActive(true);
        largePotato.SetActive(false);
        TickManager.tickManager.OnTickEvent += GrowPotato;
        isBig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isBig)
            {
                PotatoPickup();
                PlayerManager.playerManager.CropPickup(CropType.Potato, transform.position);
            }
        }
    }
}
