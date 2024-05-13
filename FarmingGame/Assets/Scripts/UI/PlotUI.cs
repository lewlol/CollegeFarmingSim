using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlotUI : MonoBehaviour
{
    public Tile[] tiles;
    Image image;
    public PlotManager pm;
    private void Awake()
    {
        image = GetComponent<Image>();
        IconColor();
    }

    public void UnlockPlot()
    {
        if (!tiles[0].isUnlocked && GameObject.Find("Player").GetComponent<Coins>().coins >= pm.plotPrice)
        {
            foreach(Tile tile in tiles)
            {
                tile.ClearPlot();
                IconColor();
            }

            pm.UpdatePrice();
        }
    }
    public void IconColor()
    {
        //If the Plot needs Clearing
        if (!tiles[0].isUnlocked)
        {
            //Make it Red
            image.color = Color.red;
        }

        //If Unlocked with Crops
        if (tiles[0].isUnlocked)
        {
            //Make it Green
            image.color = Color.green;
        }
    }
}
