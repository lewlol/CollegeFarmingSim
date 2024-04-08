using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI : MonoBehaviour
{
    public float runRadius;
    public float searchCropRadius;
    public float eatRadius;

    GameObject player;
    GameObject crop;

    public bool isRunningFromPlayer;
    public bool isSearchingForCrop;
    public bool isEatingCrop;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float cropDistance = Vector3.Distance(transform.position, crop.transform.position);

        if (playerDistance < runRadius && !isRunningFromPlayer)
            RunFromPlayer();
        else if(playerDistance > searchCropRadius && !isRunningFromPlayer && !isEatingCrop)
            SearchForCrop();

        if(cropDistance <= eatRadius && !isRunningFromPlayer && !isSearchingForCrop && !isEatingCrop)
            EatCrop();
    }
    private void RunFromPlayer()
    {
        isRunningFromPlayer = true;

        //Run Away from the Player
    }

    private void SearchForCrop()
    {
        isSearchingForCrop = true;

        //Scan for a Nearby Crop in the Radius

        //Move to that Crop
    }

    private void EatCrop()
    {
        isEatingCrop = true;

        //Eat the Crop when in radius
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, runRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchCropRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, eatRadius);
    }
}
