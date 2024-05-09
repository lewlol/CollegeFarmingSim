using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBelt : MonoBehaviour
{
    public Tool axeTool;
    public Tool hoeTool;
    public Tool[] seedTool;

    public Tool activeTool;

    public LayerMask tile;
    int currentSeed;

    //Animations
    public Animator anim;
    bool toolSwing; 
    bool toolPour;

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

        if(activeTool.type == ToolType.Seedbag)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                currentSeed++;
                if(currentSeed >= seedTool.Length) 
                {
                    currentSeed = 0;
                }
                activeTool = seedTool[currentSeed];

                UIManager.uiManager.ToolChange(activeTool.type, activeTool.crop.ToString());
            }

            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                currentSeed--;
                if(currentSeed < 0)
                { 
                    currentSeed = seedTool.Length - 1;
                }
                activeTool = seedTool[currentSeed];
            }
            UIManager.uiManager.ToolChange(activeTool.type, activeTool.crop.ToString()); 
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
                if (parent.transform.GetComponent<Tile>() != null)
                {
                    if (parent.transform.GetComponent<Tile>().isUnlocked)
                    {
                        if (!toolSwing)
                        {
                            StartCoroutine(TillGround(parent));
                            StartCoroutine(ToolSwing());
                        }
                    }
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
                    if (!toolPour) 
                    {
                        StartCoroutine(PlantSeed(parent));
                        StartCoroutine(ToolPour());
                    }
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
            activeTool = seedTool[currentSeed];
        }

        UIManager.uiManager.ToolChange(activeTool.type, activeTool.crop.ToString());
    }

    public void AddCropToSeedBag(CropType crop)
    {

    }

    IEnumerator TillGround(Transform parent)
    {
        yield return new WaitForSeconds(0.6f);
        parent.transform.GetComponent<Tile>().TillTile();
    }

    IEnumerator PlantSeed(Transform parent)
    {
        yield return new WaitForSeconds(2);
        parent.transform.GetComponent<Tile>().PlantCrops(activeTool.cropPlot);
        Debug.Log("Planted " + activeTool.crop.ToString());
    }

    IEnumerator ToolSwing()
    {
        toolSwing = true;
        anim.SetBool("isSwinging", true);

        PlayerManager.playerManager.FreezePlayer(1f);
        yield return new WaitForSeconds(1f);

        toolSwing = false;
        anim.SetBool("isSwinging", false);
    }

    IEnumerator ToolPour()
    {
        toolPour = true;
        anim.SetBool("isPouring", true);

        PlayerManager.playerManager.FreezePlayer(2f);
        yield return new WaitForSeconds(2f);

        toolPour = false;
        anim.SetBool("isPouring", false);
    }
}
