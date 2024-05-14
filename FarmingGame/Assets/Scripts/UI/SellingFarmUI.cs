using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellingFarmUI : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI amountText;

    private void Start()
    {
        UIManager.uiManager.onOpenSellingMenu += OpenMenu;
        UIManager.uiManager.onCloseSellingMenu += CloseMenu;
    }
    public void OpenMenu(int amount)
    {
        menu.SetActive(true);
        amountText.text = "I could offer you " + amount.ToString() + "?";
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }
}
