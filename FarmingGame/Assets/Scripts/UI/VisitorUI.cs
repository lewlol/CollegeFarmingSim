using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisitorUI : MonoBehaviour
{
    public GameObject UI;

    public Image cropImage;
    public TextMeshProUGUI askAmount;
    public TextMeshProUGUI coinReward;
    public TextMeshProUGUI pointsReward;

    private void Start()
    {
        UIManager.uiManager.OnOpenVisitorMenu += SetTrade;
        UIManager.uiManager.OnCloseVisitorMenu += SetUI;
    }

    public void SetTrade(string cropName, int aa, int cr, int pr, Sprite ci)
    {
        UI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        cropImage.sprite = ci;
        askAmount.text = aa.ToString() + " " + cropName;
        coinReward.text = cr.ToString() + " Coins";
        pointsReward.text = pr.ToString() + " Farm Points";
    }

    public void SetUI() 
    {
        UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
