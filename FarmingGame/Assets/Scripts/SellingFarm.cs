using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SellingFarm : MonoBehaviour
{
    public int farmWorth;
    public GameObject fade;

    public PlayerStats1 stats;

    public void IncreaseFarmWorth(int amount)
    {
        farmWorth += amount;
    }

    public void DecreaseFarmWorth(int amount)
    {
        farmWorth -= amount;
        if(farmWorth < 0)
        {
            farmWorth = 0;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (UIManager.uiManager.canOpenSellingMenu)
            {
                UIManager.uiManager.OpenSellingMenu(farmWorth);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.uiManager.canOpenInventory = false;
            UIManager.uiManager.canOpenSellingMenu = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.uiManager.canOpenInventory = true;
            UIManager.uiManager.canOpenSellingMenu = false;

            UIManager.uiManager.CloseSellingMenu();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Accept()
    {
        StartCoroutine(SellIsland());
        UIManager.uiManager.CloseSellingMenu();
        Cursor.lockState = CursorLockMode.Locked;

        stats.worth = farmWorth;
    }

    public void Deny()
    {
        UIManager.uiManager.CloseSellingMenu();
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator SellIsland()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndScene");
    }
}
