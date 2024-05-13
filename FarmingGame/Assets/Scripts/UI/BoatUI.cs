using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoatUI : MonoBehaviour
{
    public GameObject boatUI;

    //UI Images
    public Image firstCropImage;
    public Image secondCropImage;
    public Image thirdCropImage;

    //Ask Amounts
    public TextMeshProUGUI firstcropText;
    public TextMeshProUGUI secondcropText;
    public TextMeshProUGUI thirdcropText;

    //Rewards
    public TextMeshProUGUI coinRewardText;
    public TextMeshProUGUI farmPointsRewardText;

    private void Awake()
    {
        UIManager.uiManager.onBoatUI += SetUI;
        UIManager.uiManager.onCloseBoatUI += CloseUI;
    }
    public void SetUI(Sprite i1, Sprite i2, Sprite i3, int ask1, int ask2, int ask3, int coins, int points)
    {
        boatUI.SetActive(true);

        firstCropImage.sprite = i1;
        secondCropImage.sprite = i2;
        thirdCropImage.sprite = i3;

        firstcropText.text = ask1.ToString();
        secondcropText.text = ask2.ToString();
        thirdcropText.text = ask3.ToString();

        coinRewardText.text = coins.ToString() + " Coins";
        farmPointsRewardText.text = points.ToString() + " Farm Points";
    }

    public void CloseUI()
    {
        boatUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
