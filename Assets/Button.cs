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
        if(button == "LevelSelect" || button == "Level1")
        {
            background.GetComponent<Image>().sprite = back1;
        }
        else if (button == "TakeOver" || button == "Level2")
        {
            background.GetComponent<Image>().sprite = back2;
        }
        else if (button == "Settings" || button == "Level3")
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
        else if (button == "Level1")
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (button == "Level2")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (button == "Level3")
        {
            SceneManager.LoadScene("Level 3");
        }
    }
}
