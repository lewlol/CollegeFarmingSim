using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public Animator anim;
    bool swinging;

    void Update()
    {
        if (Input.GetMouseButton(0) && !swinging)
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing() 
    {
        swinging = true;
        anim.SetBool("isSwinging", true);

        yield return new WaitForSeconds(1f);

        swinging = false;
        anim.SetBool("isSwinging", false);
    }
}
