using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject optionsMenu;

    public GameObject fade;
    public void Play()
    {
        StartCoroutine(PlayGame());
    }
    public void Options()
    {
        bool optionsOpen = optionsMenu.activeSelf;
        optionsMenu.SetActive(!optionsOpen);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGame()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("IslandScene");
    }
}