using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject grassTile;
    public GameObject tilledTile;
    public GameObject sandTile;
    public GameObject waterTile;

    public bool isGrass;
    public bool isTilled;
    public bool isSand;
    public bool isWater;

    public bool hasCrops;
    private void Start()
    {
        isGrass = true;
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
    }

    public void PlantCrops(GameObject plot)
    {
        Instantiate(plot, transform.position, Quaternion.identity);
        hasCrops = true;
    }
}
