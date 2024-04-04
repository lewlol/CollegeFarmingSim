using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisitorUI : MonoBehaviour
{
    public GameObject UI;

    public TextMeshProUGUI askAmount;
    public TextMeshProUGUI coinReward;
    public TextMeshProUGUI pointsReward;

    private void Start()
    {
        UIManager.uiManager.OnOpenVisitorMenu += SetTrade;
        UIManager.uiManager.OnCloseVisitorMenu += SetUI;
    }

    public void SetTrade(string cropName, int aa, int cr, int pr)
    {
        UI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

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
