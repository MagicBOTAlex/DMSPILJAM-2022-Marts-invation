using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuScript : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    public int jeff;

    private void Awake()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && jeff != 1)
        {
            fader.gameObject.SetActive(true);
            LeanTween.scale(fader, Vector3.zero, 0f);
            LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
            {
                SceneManager.LoadScene("Menu");
            });
        }
    }
}
