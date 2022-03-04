using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static void LoadScene(string name) {
        try {
            SceneManager.LoadScene(name);
        }
        catch {
            Debug.Log($"ERROR: Could not load scene with name: {name}");
        }
    }
}
