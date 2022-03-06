using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    private void Start()
    {
        //Screen.SetResolution((int)(1920 / 1.5), (int)(1080/1.5), false);
        //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    public void ChangeFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
