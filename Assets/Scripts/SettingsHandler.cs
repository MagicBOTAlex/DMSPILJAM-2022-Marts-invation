using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SettingsHandler : MonoBehaviour
{

    private Slider soundSlider;
 
    private bool bMute, bSfxMute;

    private void Awake() {
        soundSlider = transform.GetChild(0).GetComponent<Slider>();
        if (PlayerPrefs.GetInt("isVolumeSet") == 0) {
            Debug.Log("NEW VALUE SETTING 1");
            soundSlider.value = 1f;
        }
        else {
            soundSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }


    private void FixedUpdate() {
        // Set volume
        PlayerPrefs.SetFloat("Volume", soundSlider.value);
        PlayerPrefs.SetInt("isVolumeSet", 1);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
