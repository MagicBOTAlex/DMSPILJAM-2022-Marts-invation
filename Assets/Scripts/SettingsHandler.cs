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

    private void Awake() {
        mute = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        sfxMute = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        soundSlider = transform.GetChild(2).GetComponent<Slider>();

        muteBText = mute.text;
        sfxMuteBText = sfxMute.text;
    }

    private void FixedUpdate() {
        // Set volume
    }
}
