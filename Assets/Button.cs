using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Image background;
    public Sprite back1, back2, back3;

    public string button;

    private void OnMouseEnter()
    {
        if(button == "LevelSelect")
        {
            background.GetComponent<Image>().sprite = back1;
        }
        else if (button == "TakeOver")
        {
            background.GetComponent<Image>().sprite = back2;
        }
        else if (button == "Settings")
        {
            background.GetComponent<Image>().sprite = back3;
        }

    }

    private void OnMouseDown()
    {
        if (button == "LevelSelect")
        {
            SceneManager.LoadScene("LevelSelect");
        }
        else if (button == "TakeOver")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (button == "Settings")
        {
            SceneManager.LoadScene("Settings");
        }
    }
}
