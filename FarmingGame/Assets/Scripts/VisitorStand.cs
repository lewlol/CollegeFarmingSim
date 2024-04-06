using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisitorStand : MonoBehaviour
{
    public float visitorCooldown;
    float c;

    public VisitorData[] visitors;
    public VisitorData activeVisitor;

    bool isAvailable;
    bool inRadius;

    //Trade Stuff
    CropData cd;
    CropType ct;
    int askAmount;
    int coinReward;
    int pointsReward;

    int invAmount;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        isAvailable = true;
        c = visitorCooldown;
    }
    private void Update()
    {
        if (isAvailable)
        {
            float countdown = c -= Time.deltaTime;
            if (countdown <= 0)
            {
                c = visitorCooldown;
                SpawnVisitor();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && inRadius && !isAvailable)
        {
            OpenMenu();
        }
    }

    private void ChooseVisitor()
    {
        int rarity = Random.Range(0, 11);
        if (rarity <= 4) // 0 - 4 (40%) Common
        {
            CheckRarity(Rarity.Common);
        }
        else if (rarity > 4 && rarity <= 7) // 5 - 7 (30%) Rare
        {
            CheckRarity(Rarity.Rare);
        }
        else if (rarity > 7 && rarity <= 9) // 8 - 9 (20%) Epic
        {
            CheckRarity(Rarity.Epic);
        }
        else if(rarity == 10) // 10 (10%) Legendary
        {
            CheckRarity(Rarity.Legendary);
        }
    }

    private void CheckRarity(Rarity rarity)
    {
        int randomVisitor = Random.Range(0, visitors.Length);
        if (visitors[randomVisitor].rarity != rarity)
        {
            CheckRarity(rarity);
        }
        activeVisitor = visitors[randomVisitor];
    }
    private void SetTrade()
    {
        if (activeVisitor.multipleCrops)
        {
            int ranCrop = Random.Range(0, activeVisitor.crops.Length);
            cd = activeVisitor.crops[ranCrop];
        }
        else
        {
            cd = activeVisitor.crops[0];
        }

        askAmount = Random.Range(activeVisitor.minTradeAmount, activeVisitor.maxTradeAmount);

        coinReward = askAmount * cd.cropPrice;
        pointsReward = askAmount * cd.cropPoints;

        ct = cd.cropType;
    }
    private void SpawnVisitor()
    {
        isAvailable = false;

        //Choose a Visitor
        ChooseVisitor();

        //Choose Trade Crop and Amount & Set Rewards based on Amount (Crop Data)
        SetTrade();

        //Spawn Visitor Model


        //Visitor Generocity Offset (DO THIS LATER WITH VISITOR lOGBOOK AND TRACKING VISITOR TRADED TIMES)
    }

    public void OpenMenu()
    {
        UIManager.uiManager.OpenVisitorMenu(cd.cropName, askAmount, coinReward, pointsReward, cd.cropSprite);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRadius = false;
            UIManager.uiManager.CloseVisitorMenu();
        }
    }

    public void Accept()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        switch (ct)
        { 
            case CropType.Wheat:
                invAmount = inventory.wheat;
                break;
            case CropType.Pumpkin: 
                invAmount = inventory.pumpkin;
                break;
            case CropType.Potato:
                invAmount = inventory.potato;
                break;
            case CropType.Carrot:
                invAmount = inventory.carrot;
                break;
        }

        if(invAmount >= askAmount) //Trade can go through
        {
            //Minus from Inventory
            switch (ct)
            {
                case CropType.Wheat:
                    inventory.wheat -= askAmount;
                    break;
                case CropType.Pumpkin:
                    inventory.pumpkin -= askAmount;
                    break;
                case CropType.Potato:
                    inventory.potato -= askAmount;
                    break;
                case CropType.Carrot:
                    inventory.carrot -= askAmount;
                    break;
            }

            //Add Coins
            PlayerManager.playerManager.AddCoins(coinReward);

            //Add Farm Points
            PlayerManager.playerManager.AddFarmPoints(pointsReward);

            //Close Inven
            UIManager.uiManager.CloseVisitorMenu();

            //Reset Visitor
            ResetVisitor();
        }
    }

    public void Deny()
    {
        UIManager.uiManager.CloseVisitorMenu();

        //Reset Visitor
        ResetVisitor();
    }

    public void ResetVisitor()
    {
        activeVisitor = null;
        cd = null;
        ct = CropType.None;
        askAmount = 0;
        coinReward = 0;
        pointsReward = 0;
        invAmount = 0;

        isAvailable = true;
    }
}
