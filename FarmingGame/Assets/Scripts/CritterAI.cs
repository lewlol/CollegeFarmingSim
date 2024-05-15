using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAI : MonoBehaviour
{
    public float runRadius;

    public CritterData cd;
    CharacterController charcontrol;
    GameObject player;

    float timer;

    private void Awake()
    {
        player = GameObject.Find("Player");
        charcontrol = GetComponent<CharacterController>();
        timer = 120;
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if (playerDistance < runRadius)
        {
            RunFromPlayer();
        }

        float countdown = timer -= Time.deltaTime;
        if(countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void RunFromPlayer()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        charcontrol.Move(transform.forward * cd.critterSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, runRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Net")
        {
            Destroy(gameObject);
            PlayerManager.playerManager.AddFarmWorth(10);
        }
    }
}
