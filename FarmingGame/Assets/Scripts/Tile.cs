using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject grassTile;
    public GameObject tilledTile;
    public GameObject sandTile;
    public GameObject waterTile;

    public GameObject nature;

    public bool isGrass;
    public bool isTilled;
    public bool isSand;
    public bool isWater;

    public bool hasCrops;
    public bool isUnlocked;

    public GameObject guideIcon;
    public Sprite hoe;
    public Sprite seed;

    private void Start()
    {
        isGrass = true;

        GuideIcon();
    }
    public void TillTile()
    {
        grassTile.SetActive(false);
        tilledTile.SetActive(true);
        sandTile.SetActive(false);
        waterTile.SetActive(false);

        isGrass = false;
        isTilled = true;
        isSand = false;
        isWater = false;

        GuideIcon();
    }

    public void ClearPlot()
    {
        isUnlocked = true;
        nature.SetActive(false);
        GuideIcon();
    }

    public void PlantCrops(GameObject plot)
    {
        Instantiate(plot, transform.position, Quaternion.identity);
        hasCrops = true;

        GuideIcon();
    }

    public void GuideIcon()
    {
        guideIcon.SetActive(isUnlocked); //The Plot is Unlocked and needs the Guide icon
        if (isGrass) //The plot is grass and needs tilling
        {
            guideIcon.GetComponent<SpriteRenderer>().sprite = hoe;
            return;
        }
        else if (isTilled) // The plot is tilled and needs seeds
        {
            if (hasCrops) //Seeds are planted so turn it off
            {
                guideIcon.SetActive(false);
                return;
            }

            guideIcon.GetComponent<SpriteRenderer>().sprite = seed;
        }
    }
}
