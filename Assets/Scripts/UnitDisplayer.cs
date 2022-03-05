using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitDisplayer : MonoBehaviour
{
    public int towerIndex = -1;
    private RectTransform canvasTrans;
    private Text text;

    private void Awake() {
        canvasTrans = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }
    private void Start() {
        // Create text field, so we use the main canvas 

        RectTransform trans = gameObject.AddComponent<RectTransform>();
        transform.SetParent(canvasTrans);
        trans.anchoredPosition = Camera.main.WorldToScreenPoint(transform.position);

        text = gameObject.AddComponent<Text>();
        text.text = "hello";
    }
    private void FixedUpdate() {
        //int units = GameManagerScript.Towers[towerIndex].UnitsInside;

        // Display units
    }
}
