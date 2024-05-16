using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject fade;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void MainMenu()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("IslandScene");
    }
}
