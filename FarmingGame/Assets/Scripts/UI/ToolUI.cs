using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolUI : MonoBehaviour
{
    public GameObject hoeHighlight;
    public GameObject axeHighlight;
    public GameObject seedHighlight;

    private void Start()
    {
        UIManager.uiManager.OnToolChange += UpdateUI;
    }
    public void UpdateUI(ToolType tt)
    {
        if(tt == ToolType.Hoe)
        {
            hoeHighlight.SetActive(true);
            axeHighlight.SetActive(false);
            seedHighlight.SetActive(false);
        }else if(tt == ToolType.Axe)
        {
            hoeHighlight.SetActive(false);
            axeHighlight.SetActive(true);
            seedHighlight.SetActive(false);
        }else if(tt == ToolType.Seedbag)
        {
            hoeHighlight.SetActive(false);
            axeHighlight.SetActive(false);
            seedHighlight.SetActive(true);
        }
    }
}
