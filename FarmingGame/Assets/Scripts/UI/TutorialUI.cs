using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public TextMeshProUGUI tutText;
    public GameObject panel;
    private void Awake()
    {
        UIManager.uiManager.OnUpdateTutorial += UpdateText;
    }
    public void UpdateText(string t)
    {
        if(t == "off")
        {
            panel.SetActive(false);
        }

        tutText.text = t;
    }
}
