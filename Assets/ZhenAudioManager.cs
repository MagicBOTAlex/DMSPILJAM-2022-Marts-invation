using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhenAudioManager : MonoBehaviour
{
    static ZhenAudioManager Instance;
    public List<AudioClip> audioClips_ = new List<AudioClip>();
    public static List<AudioClip> audioClips = new List<AudioClip>();
    AudioSource audioSource;

    private static bool mute, sfxMute;
    private static void Awake() {
        LoadSettings();
    }

    /// <summary>
    /// Checks if there is a preset of sounds settings in player prefs and applies the settings
    /// </summary>
    private static void LoadSettings() {
        // Get settings
        float volume = PlayerPrefs.GetFloat("Volume");
        if (PlayerPrefs.GetInt("Mute") == 1) {
            mute = true;
        }
        else {
            mute = false;
        }
        if (PlayerPrefs.GetInt("SFXMute") == 1) {
            sfxMute = true;
        }
        else {
            sfxMute = false;
        }
        // Apply settings
        Instance.audioSource.volume = volume;

    }
    private void Start()
    {
        if (audioClips_.Count == 0)
        {
            audioClips_ = GetComponent<AudioManager>().sounds.Select(x=>x.clip).ToList();
        }

        audioClips = audioClips_;
        Instance = this;
        //PlaySound(audioClips[1], true).loop = true;
    }

    public static AudioSource PlaySound(string nameOfClip, bool fadeIn = false)
    {
        // Return if sfx mute
        if (sfxMute) {
            return new AudioSource();
        }
        Instance.StartCoroutine(Instance.StartSound(audioClips.Find(x=>x.name == nameOfClip), fadeIn));
        return Instance.audioSource;
    }

    public static void StopAll()
    {
        var allSources = Instance.gameObject.GetComponents<AudioSource>();
        foreach (var source in allSources)
        {
            source.Stop();
        }
    }

    IEnumerator StartSound(AudioClip clip, bool fadeIn)
    {
        var AS = gameObject.AddComponent<AudioSource>();
        AS.clip = clip;

        if (fadeIn)
        {
            AS.volume = 0;
            StartCoroutine(StartMusicFadeIn(AS));
        }

        audioSource = AS;

        AS.Play();
        yield return new WaitUntil(() => !AS.isPlaying);
        Destroy(AS);
    }

    public IEnumerator StartMusicFadeIn(AudioSource AS)
    {
        while (true)
        {
            if (AS.volume >= 1)
            {
                break;
            }
            AS.volume += 0.01f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
