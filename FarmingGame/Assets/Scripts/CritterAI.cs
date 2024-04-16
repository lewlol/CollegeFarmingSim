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

    private void Awake()
    {
        player = GameObject.Find("Player");
        charcontrol = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if (playerDistance < runRadius)
        {
            RunFromPlayer();
        }else if(playerDistance > runRadius && playerDistance < searchCropRadius)
        {
            SearchForCrop();
        }
    }
    private void RunFromPlayer()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        charcontrol.Move(transform.forward * cd.critterSpeed * Time.deltaTime);
    }

    private void SearchForCrop()
    {
    }

    private void EatCrop()
    {
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
