using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
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

    public void ChooseCrops()
    {
        int c1 = Random.Range(0, crops.Length);
        firstCrop = crops[c1];

        int c2 = Random.Range(0, crops.Length);
        firstCrop = crops[c2];

        int c3 = Random.Range(0, crops.Length);
        firstCrop = crops[c3];

        firstCropAmount = Random.Range(10, 51);
        secondCropAmount = Random.Range(10, 51);
        thirdCropAmount = Random.Range(10, 51);
    }

    public void SetRewards()
    {
        totalCoins = (firstCropAmount * firstCrop.cropPrice) + (secondCropAmount * secondCrop.cropPrice) + (thirdCropAmount * thirdCrop.cropPrice);
        totalPoints = (firstCropAmount * firstCrop.cropPoints) + (secondCropAmount * secondCrop.cropPoints) + (thirdCropAmount * thirdCrop.cropPoints);
    }
}
