using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SettingsHandler : MonoBehaviour
{
    private TextMeshProUGUI mute;
    private TextMeshProUGUI sfxMute;
    private Slider soundSlider;
    private string muteBText, sfxMuteBText;
    private bool bMute, bSfxMute;

    private void Awake() {
        mute = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        sfxMute = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        soundSlider = transform.GetChild(2).GetComponent<Slider>();

        muteBText = mute.text;
        sfxMuteBText = sfxMute.text;
    }

    public void ToggleMute() {
        Debug.Log("toggling mute!");
        bMute = !bMute;
    }
    public void ToggleSfxMute() {
        Debug.Log("toggling sfx mute!");
        bSfxMute = !bSfxMute;
    }

    private void FixedUpdate() {
        // Set volume
        PlayerPrefs.SetFloat("Volume", soundSlider.value);
        // Set mute
        if (bMute) {
            PlayerPrefs.SetInt("Mute", 1);
        }
        else {
            PlayerPrefs.SetInt("Mute", 0);
        }
        // Set sfx mute
        if (bSfxMute) {
            PlayerPrefs.SetInt("SFXMute", 1);
        }
        else {
            PlayerPrefs.SetInt("SFXMute", 0);
        }
        
    }
}
