using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUnitDisplayer2 : MonoBehaviour
{
    GameObject second;
    public TextMesh text;
    int start = 20;
    void Awake() {
        second = GetComponentInParent<DestroyOnTrigger>().gameObject;
    }

    void FixedUpdate() {
        int left = start - second.GetComponent<DestroyOnTrigger>().ObjectsDestroyed;
        text.text = left.ToString();
    }
}
