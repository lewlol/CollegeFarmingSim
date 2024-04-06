using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    }
    public void UpdateUI(float wheat, float pumpkin, float carrot)
    {
        wheatText.text = wheat.ToString();
        pumpkinText.text = pumpkin.ToString();
        carrotText.text = carrot.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool i = ui.activeSelf;
            ui.SetActive(!i);
        }
    }
}
