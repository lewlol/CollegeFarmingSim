using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Awake()
    {
        PlayerManager.playerManager.OnTillGround += TillGroundTutorial;
        UIManager.uiManager.UpdateTutorial("Get To Work On Your Farm by Tilling a plot with 'RMB', while standing over it");
    }

    public void TillGroundTutorial()
    {
        PlayerManager.playerManager.OnTillGround -= TillGroundTutorial;

        PlayerManager.playerManager.OnPlantCrop += PlantCropTutorial;

        UIManager.uiManager.UpdateTutorial("Nice! Next you will want to place your crops. Switch to the seedback with '3' and plant a crop with RMB");
    }

    public void PlantCropTutorial()
    {
        PlayerManager.playerManager.OnPlantCrop -= PlantCropTutorial;

        PlayerManager.playerManager.OnBuyPlot += BuyPlotTutorial;

        UIManager.uiManager.UpdateTutorial("Well Done! you have your first set of crops now. Lets get more plots from the laptop in the barn!");
    }

    public void BuyPlotTutorial()
    {
        PlayerManager.playerManager.OnBuyPlot -= BuyPlotTutorial;

        PlayerManager.playerManager.OnAcceptTrade += TradeVisitorTutorial;

        UIManager.uiManager.UpdateTutorial("Now that we have more plots we can gather some more crops to accept our first trade at the visitor stand!");
    }

    public void TradeVisitorTutorial()
    {
        PlayerManager.playerManager.OnAcceptTrade -= TradeVisitorTutorial;
        UIManager.uiManager.UpdateTutorial("off");
    }
}
