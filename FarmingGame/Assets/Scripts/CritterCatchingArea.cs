using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterCatchingArea : MonoBehaviour
{
    public SphereCollider sc;

    public void Start()
    {
        PlayerManager.playerManager.OnCatchCritter += EnableCollider;
    }
    public void EnableCollider()
    {
        StartCoroutine(Enable());
    }
    public IEnumerator Enable()
    {
        sc.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sc.enabled = false;
    }
}
