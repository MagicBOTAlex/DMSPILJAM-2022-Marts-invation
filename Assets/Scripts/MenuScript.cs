using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    /*[SerializeField] RectTransform fader;


    private void Awake()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }*/
    void Awake() { 
        
        if (!PlayerPrefs.HasKey("Volume")) {
            Debug.Log("NEWWW");
            PlayerPrefs.SetFloat("Volume", 1f);
        }
        
    }

    public static void LoadScene(string name) {
        try {
            SceneManager.LoadScene(name);
        }
        catch {
            Debug.Log($"ERROR: Could not load scene with name: {name}");
        }
    }
}
