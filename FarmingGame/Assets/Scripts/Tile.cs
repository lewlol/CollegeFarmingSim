using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject grassTile;
    public GameObject tilledTile;
    public GameObject sandTile;
    public GameObject waterTile;


    public void TillTile()
    {
        grassTile.SetActive(false);
        tilledTile.SetActive(true);
        sandTile.SetActive(false);
        waterTile.SetActive(false);
    }
}
