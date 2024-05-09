using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopMenu : MonoBehaviour
{
    public GameObject laptopUI;
    public GameObject plotMenu;
    private void Update()
    {
        if (UIManager.uiManager.canOpenLaptop)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                laptopUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void TurnOffUI()
    {
        laptopUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ClearPlotsMenu()
    {
        bool on = plotMenu.activeSelf;
        plotMenu.SetActive(!on);
    }
}
