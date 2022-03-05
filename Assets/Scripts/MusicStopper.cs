using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStopper : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GameObject.FindGameObjectWithTag("Music"));
    }
}
