using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitDisplayer : MonoBehaviour
{
    public int towerIndex = -1;
    private RectTransform canvasTrans;
    private TextMesh text;
    Camera cam;
    private void Awake() {
        canvasTrans = GameObject.Find("Canvas").GetComponent<RectTransform>();
        cam = Camera.main;
    }
    private void Start() {
        // Create text field, so we use the main canvas 

        
        transform.SetParent(canvasTrans);
        Debug.Log(transform.position);
        text = GetComponentInChildren<TextMesh>();
        text.text = "sussi";
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
