using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TutorialUnitDisplayer : MonoBehaviour
{
    public TextMesh text;
    GameObject first;

    void Awake() {
        first = transform.GetComponentInParent<TutorialSendUnits>().gameObject;
    }
    
    void FixedUpdate() {
        UpdateUD();
    }

    void UpdateUD() {
        int units = first.GetComponent<TutorialSendUnits>().firstUnits;
        text.text = units.ToString();
    }
}
