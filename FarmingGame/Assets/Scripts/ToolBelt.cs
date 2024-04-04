using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBelt : MonoBehaviour
{
    public Tool axeTool;
    public Tool hoeTool;

    public Tool activeTool;

    public LayerMask tile;

    private void Start()
    {
        activeTool = hoeTool;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (activeTool.type)
            {
                case ToolType.Hoe:
                    UseHoe();
                    break;
                case ToolType.Axe:
                    UseAxe();
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

                parent.transform.GetComponent<Tile>().TillTile();
                Debug.Log("Hit Tile");
            }
        }
    }

    private void UseAxe()
    {

    }
}
