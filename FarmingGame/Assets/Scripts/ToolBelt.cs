using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBelt : MonoBehaviour
{
    public Tool axeTool;
    public Tool hoeTool;
    public Tool seedTool;

    public Tool activeTool;

    public LayerMask tile;

    private void Start()
    {
        activeTool = hoeTool;
    }
    private void Update()
    {
        ChangeTool();

        if (Input.GetMouseButtonDown(0))
        {
            switch (activeTool.type)
            {
                case ToolType.Hoe:
                    UseHoe();
                    break;
                case ToolType.Axe:
                    UseAxe();
                    break;
                case ToolType.Seedbag:
                    UseSeedBag(); 
                    break;
            }
        }
    }

    private void UseHoe()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, tile))
        {
            if(hit.transform.tag == "Tile")
            {
                Transform p = hit.transform.parent;
                Transform parent = p.parent;
                if (parent.transform.GetComponent<Tile>().isUnlocked)
                {
                    parent.transform.GetComponent<Tile>().TillTile();
                    Debug.Log("Hit Tile");
                }
            }
        }
    }

    private void UseAxe()
    {

    }

    private void UseSeedBag()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, tile))
        {
            if (hit.transform.tag == "Tile")
            {
                Transform p = hit.transform.parent;
                Transform parent = p.parent;

                if(parent.transform.GetComponent<Tile>().isTilled == true && parent.transform.GetComponent<Tile>().hasCrops == false)
                {
                    parent.transform.GetComponent<Tile>().PlantCrops(activeTool.cropPlot);
                    Debug.Log("Planted " + activeTool.crop.ToString());
                }
            }
        }
    }

    private void ChangeTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeTool = hoeTool;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeTool = axeTool;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeTool = seedTool;
        }

        UIManager.uiManager.ToolChange(activeTool.type);
    }
}
