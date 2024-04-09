using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI : MonoBehaviour
{
    public float runRadius;
    public float searchCropRadius;
    public float eatRadius;

    public CritterData cd;
    CharacterController charcontrol;
    GameObject player;
    GameObject crop;

    public bool isRunningFromPlayer;
    public bool isSearchingForCrop;
    public bool isEatingCrop;

    float cropDistance;
    private void Awake()
    {
        player = GameObject.Find("Player");
        charcontrol = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if(crop != null)
            cropDistance = Vector3.Distance(transform.position, crop.transform.position);

        if (playerDistance < runRadius && !isRunningFromPlayer)
            RunFromPlayer(playerDistance);
        else if(playerDistance > searchCropRadius && !isRunningFromPlayer && !isEatingCrop)
            SearchForCrop();

        if(cropDistance <= eatRadius && !isRunningFromPlayer && !isSearchingForCrop && !isEatingCrop)
            EatCrop();
    }
    private void RunFromPlayer(float playerDistance)
    {
        Debug.Log("Running from Player");
        isRunningFromPlayer = true;

        Vector3 moveDir = transform.position = player.transform.position;
        charcontrol.Move(moveDir * cd.critterSpeed * Time.deltaTime);

        if(playerDistance > searchCropRadius)
        {
            isRunningFromPlayer = false;
        }
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
