using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI wheatText;
    public TextMeshProUGUI pumpkinText;
    public TextMeshProUGUI carrotText;

    private void Awake()
    {
        UIManager.uiManager.OnUpdateInventoryUI += UpdateUI;
        UIManager.uiManager.OnOpenVisitorMenu += ForceInvClose;
    }
    public void UpdateUI(float wheat, float pumpkin, float carrot)
    {
        wheatText.text = wheat.ToString();
        pumpkinText.text = pumpkin.ToString();
        carrotText.text = carrot.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && UIManager.uiManager.canOpenInventory)
        {
            bool i = ui.activeSelf;
            ui.SetActive(!i);
        }
    }

    public void ForceInvClose(string f, int a, int b, int c, Sprite d)
    {
        ui.SetActive(false);
    }
}
