using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStopper : MonoBehaviour
{
    private void Awake()
    {
        try
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }
        catch
        {

        }
    }
}
