using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitDisplayer : MonoBehaviour
{
    public int towerIndex = -1;
    private RectTransform canvasTrans;
    private Text text;
    Camera cam;
    private void Awake() {
        canvasTrans = GameObject.Find("Canvas").GetComponent<RectTransform>();
        cam = Camera.main;
    }
    private void Start() {
        // Create text field, so we use the main canvas 

        RectTransform trans = gameObject.AddComponent<RectTransform>();
        transform.SetParent(canvasTrans);
        Debug.Log(transform.position);
        trans.anchoredPosition = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y));
        trans.pivot = new Vector2(-9, -5);

        text = gameObject.AddComponent<Text>();
        text.text = "hello";
    }
    private void FixedUpdate() {
        //int units = GameManagerScript.Towers[towerIndex].UnitsInside;

        // Display units
    }

    private float ConvertUnit2Px(float unit) {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;
        return (unit * pixelH)/(ortho * 2);
    }
}
