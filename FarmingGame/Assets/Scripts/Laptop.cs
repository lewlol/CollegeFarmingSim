using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.uiManager.canOpenLaptop = true;
            UIManager.uiManager.canOpenInventory = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIManager.uiManager.canOpenLaptop = false;
            UIManager.uiManager.canOpenInventory = true;
        }
    }
}
