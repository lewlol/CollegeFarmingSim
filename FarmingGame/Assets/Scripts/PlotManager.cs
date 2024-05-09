using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    public int plotPrice;
    public TextMeshProUGUI price;

    private void Awake()
    {
        plotPrice = 100;
        price.text = "Current Price: " + plotPrice;
    }
    public void UpdatePrice()
    {
        plotPrice = plotPrice * 2;
        price.text = "Current Price: " + plotPrice;
    }
}
