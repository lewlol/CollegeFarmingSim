using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool isUnlocked;
    bool isAvailable;
    bool canUnlock;

    GameObject player;
    public CropData[] crops;

    //Trade Stuff
    public CropData firstCrop;
    public CropData secondCrop;
    public CropData thirdCrop;

    public int firstCropAmount;
    public int secondCropAmount;
    public int thirdCropAmount;

    public int totalCoins;
    public int totalPoints;

    //Costs to Unlock
    public int coinCost;

    public float delay;
    float c;

    //Objects
    public GameObject boat;
    public GameObject debris;
    public GameObject docks;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && UIManager.uiManager.canOpenBoatTrade && isUnlocked && !isAvailable)
        {
            OpenMenu();
        }

        if (isUnlocked && isAvailable)
        {
            float countDown = c -= Time.deltaTime;
            if (countDown <= 0)
            {
                boat.SetActive(true);
                ChooseCrops();
                isAvailable = false;
            }
        }

        if (canUnlock)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.GetComponent<Coins>().coins >= coinCost)
                {
                    PlayerManager.playerManager.RemoveCoins(coinCost);
                    Unlock();
                }
            }
        }
    }
    public void ChooseCrops()
    {
        boat.GetComponent<Animator>().SetBool("isLeaving", false);

        int c1 = Random.Range(0, crops.Length);
        firstCrop = crops[c1];

        int c2 = Random.Range(0, crops.Length);
        secondCrop = crops[c2];

        int c3 = Random.Range(0, crops.Length);
        thirdCrop = crops[c3];

        firstCropAmount = Random.Range(10, 51);
        secondCropAmount = Random.Range(10, 51);
        thirdCropAmount = Random.Range(10, 51);

        SetRewards();

        isAvailable = false;
    }

    public void SetRewards()
    {
        totalCoins = (firstCropAmount * firstCrop.cropPrice) + (secondCropAmount * secondCrop.cropPrice) + (thirdCropAmount * thirdCrop.cropPrice);
        totalPoints = (firstCropAmount * firstCrop.cropPoints) + (secondCropAmount * secondCrop.cropPoints) + (thirdCropAmount * thirdCrop.cropPoints);
    }

    public void OpenMenu()
    {
        //Set UI
        UIManager.uiManager.BoatUI(firstCrop.cropSprite, secondCrop.cropSprite, thirdCrop.cropSprite, firstCropAmount, secondCropAmount, thirdCropAmount, totalCoins, totalPoints);
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked)
        {
            if (other.gameObject.tag == "Player")
            {
                UIManager.uiManager.canOpenBoatTrade = true;
                UIManager.uiManager.canOpenInventory = false;
            }
        }
        else
        {
            UIManager.uiManager.UnlockTextShow(coinCost, "Boat Trading");
            UIManager.uiManager.canOpenInventory = false;
        }

        if(other.gameObject.tag == "Player")
        {
            canUnlock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isUnlocked)
        {
            if (other.gameObject.tag == "Player")
            {
                UIManager.uiManager.canOpenBoatTrade = false;
                UIManager.uiManager.canOpenInventory = true;

                UIManager.uiManager.CloseBoatUI();
            }
        }
        else
        {
            UIManager.uiManager.DisableUnlockText();
        }
        if (other.gameObject.tag == "Player")
        {
            canUnlock = false;
        }

    }

    public void Accept()
    {
        AttemptFirstCrop();
    }

    private void AttemptFirstCrop()
    {
        Inventory inv = player.GetOrAddComponent<Inventory>();
        switch (firstCrop.cropType)
        {
            case CropType.Wheat:
                if (firstCropAmount <= inv.wheat) { AttemptSecondCrop(); }
                    break;
            case CropType.Pumpkin:
                if(firstCropAmount <= inv.pumpkin) { AttemptSecondCrop(); }
                break;
            case CropType.Carrot:
                if(firstCropAmount <= inv.carrot) { AttemptSecondCrop(); }
                break;
            case CropType.Potato:
                if(firstCropAmount <= inv.potato) { AttemptSecondCrop(); }
                break;
        }
    }
    private void AttemptSecondCrop()
    {
        Inventory inv = player.GetOrAddComponent<Inventory>();
        switch (secondCrop.cropType)
        {
            case CropType.Wheat:
                if (secondCropAmount <= inv.wheat) { AttemptThirdCrop(); }
                break;
            case CropType.Pumpkin:
                if (secondCropAmount <= inv.pumpkin) { AttemptThirdCrop(); }
                break;
            case CropType.Carrot:
                if (secondCropAmount <= inv.carrot) { AttemptThirdCrop(); }
                break;
            case CropType.Potato:
                if (secondCropAmount <= inv.potato) { AttemptThirdCrop(); }
                break;
        }
    }

    private void AttemptThirdCrop()
    {
        Inventory inv = player.GetOrAddComponent<Inventory>();
        switch (thirdCrop.cropType)
        {
            case CropType.Wheat:
                if (thirdCropAmount <= inv.wheat) { GiveRewards(); }
                break;
            case CropType.Pumpkin:
                if (thirdCropAmount <= inv.pumpkin) { GiveRewards(); }
                break;
            case CropType.Carrot:
                if (thirdCropAmount <= inv.carrot) { GiveRewards(); }
                break;
            case CropType.Potato:
                if (thirdCropAmount <= inv.potato) { GiveRewards(); }
                break;
        }
    }

    private void GiveRewards()
    {
        PlayerManager.playerManager.AddCoins(totalCoins);
        PlayerManager.playerManager.AddFarmPoints(totalPoints);

        UIManager.uiManager.CloseBoatUI();
        ResetTrade();
    }

    public void Deny()
    {
        UIManager.uiManager.CloseBoatUI();
        ResetTrade();
    }

    public void Unlock()
    {
        isUnlocked = true;
        isAvailable = true;
        debris.SetActive(false);
        docks.SetActive(true);
        UIManager.uiManager.DisableUnlockText();
    }

    private void ResetTrade()
    {
        boat.GetComponent<Animator>().SetBool("isLeaving", true);
        StartCoroutine(BoatLeaving());
        firstCrop = null;
        secondCrop = null;
        thirdCrop = null;

        firstCropAmount = 0;
        secondCropAmount = 0;
        thirdCropAmount = 0;

        totalCoins = 0;
        totalPoints = 0;

        isAvailable = true;
        c = delay;
    }

    IEnumerator BoatLeaving()
    {
        yield return new WaitForSeconds(20f);
        boat.SetActive(false);
    }
}
