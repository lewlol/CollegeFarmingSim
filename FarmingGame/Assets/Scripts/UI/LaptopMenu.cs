using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopMenu : MonoBehaviour
{
    public GameObject laptopUI;

    public void SetUI()
    {
        bool i = laptopUI.activeSelf;
        laptopUI.SetActive(!i);
    }
}
