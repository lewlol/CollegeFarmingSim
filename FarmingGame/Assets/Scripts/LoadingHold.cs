using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingHold : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject fade;

    private void Start()
    {
        StartCoroutine(TurnOffLoading());
    }
    IEnumerator TurnOffLoading()
    {
        yield return new WaitForSeconds(1f);
        loadingScreen.SetActive(false);
        fade.SetActive(true);
    }
}
