using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolUI : MonoBehaviour
{
    public GameObject hoeHighlight;
    public GameObject axeHighlight;
    public GameObject seedHighlight;

    public GameObject seedIcon;



    private void Start()
    {
        UIManager.uiManager.OnToolChange += UpdateUI;
    }
    public void UpdateUI(ToolType tt, string cropName)
    {
        if(tt == ToolType.Hoe)
        {
            hoeHighlight.SetActive(true);
            axeHighlight.SetActive(false);
            seedHighlight.SetActive(false);
            seedIcon.SetActive(false);
        }
        else if(tt == ToolType.Axe)
        {
            hoeHighlight.SetActive(false);
            axeHighlight.SetActive(true);
            seedHighlight.SetActive(false);
            seedIcon.SetActive(false);
        }
        else if(tt == ToolType.Seedbag)
        {
            hoeHighlight.SetActive(false);
            axeHighlight.SetActive(false);
            seedHighlight.SetActive(true);

            seedIcon.SetActive(true);

            seedIcon.GetComponent<TextMeshProUGUI>().text = cropName;
        }
    }
}
