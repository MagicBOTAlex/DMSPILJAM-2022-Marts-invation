using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject takeOverButton, levelSelectButton, settingsButton;
    public Sprite back1, back2, back3;


  

    public static void LoadScene(string name) {
        try {
            SceneManager.LoadScene(name);
        }
        catch {
            Debug.Log($"ERROR: Could not load scene with name: {name}");
        }
    }
}
