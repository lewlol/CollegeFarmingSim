using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject hoe;
    public GameObject axe;
    public GameObject seedBag;

    private void Start()
    {
        PlayerManager.playerManager.OnChangeTool += ChangeTool;
    }

    public void ChangeTool(ToolType tt)
    {
        switch (tt) 
        {
            case ToolType.Hoe:
                hoe.SetActive(true);
                seedBag.SetActive(false);
                axe.SetActive(false);
                break;
            case ToolType.Axe:
                hoe.SetActive(false); 
                seedBag.SetActive(false);
                axe.SetActive(true);
                break;
            case ToolType.Seedbag:
                seedBag.SetActive(true);
                hoe.SetActive(false);
                axe.SetActive(false);
                break;
        }
    }
}
