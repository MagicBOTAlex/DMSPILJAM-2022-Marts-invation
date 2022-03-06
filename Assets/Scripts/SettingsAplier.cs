using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsAplier : MonoBehaviour
{
    bool mute, sfxMute;
    void Awake() {
        LoadSettings();
    }

    /// <summary>
    /// Checks if there is a preset of sounds settings in player prefs and applies the settings
    /// </summary>
    private void LoadSettings() {
        // Get settings
        float volume = PlayerPrefs.GetFloat("Volume");

        // Apply settings
        AudioListener.volume = volume;


        Debug.Log($"Setting volume to {volume}");
        Debug.Log($"Setting sfx mute to {sfxMute}");

    }
}
