using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    public void ChangeFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
