using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbillityCooldDown : MonoBehaviour
{
    public GameObject overlayPref;
    private Camera cam;

    private void Awake() {
        if (overlayPref == null) {
            Destroy(this);
        }
        cam = Camera.main;
    }

    private void Start() {
        // Get and spawn the overlays needed for all the abillities
        SpawnOverlays();
    }
    private void Update() {
        // Update every abillity overlay
        for (int i = 0; i < GameManagerScript.Abillities.Count; ++i) {
            SpriteRenderer sr = GameManagerScript.Abillities[i].Overlay.GetComponent<SpriteRenderer>();
            if (GameManagerScript.Abillities[i].IsCooling == true) {
                if (GameManagerScript.Abillities[i].curCooldown < GameManagerScript.Abillities[i].Cooldown) { // While cooling down abillity
                    sr.enabled = true;
                    GameManagerScript.Abillities[i].curCooldown += Time.deltaTime;
                    // Get the percentage of how much the overlay should cover of the buttton
                    float distFromCompl = 1 - GameManagerScript.Abillities[i].curCooldown / GameManagerScript.Abillities[i].Cooldown;
                    UpdateOverlay(GameManagerScript.Abillities[i].Overlay, distFromCompl, GameManagerScript.Abillities[i].FraqScale, GameManagerScript.Abillities[i].Dist2Center, GameManagerScript.Abillities[i].StartPos.y);
                    //Debug.Log(distFromCompl);
                }
                else { // Done with coolDown
                    GameManagerScript.Abillities[i].curCooldown = 0f;
                    GameManagerScript.Abillities[i].IsCooling = false;                 
                }
            }
            else {
                sr.enabled = false;
            }
        }
    }

    /// <summary>
    /// Apllies varies changes to the specified overlay. It scales the gameObject on the y-axis based on how what percentage of the duration
    /// the current interval is at. It also moves the overlay down to compensate for the contraction from the bottom when scaling on the y-axis.
    /// <param name="overlay"> The gameObject of the overlay to be affected.</param>
    /// <param name="inter"> A normalized float, representing the percantage of duration.</param>
    /// </summary>
    private void UpdateOverlay(GameObject overlay, float inter, float fraq, float dist2cent, float oriPos) { 
        // Perform y-scale interpolation
        overlay.transform.localScale = new Vector3(overlay.transform.localScale.x, fraq * inter * 100f, overlay.transform.localScale.z);
        // Move sprite downwards to compensate from bottom contraction
        overlay.transform.position = new Vector3(overlay.transform.position.x, oriPos - dist2cent * (1 - inter), overlay.transform.position.z);
    }

    /// <summary>
    /// Gets all the overlays needed for all abillity buttons, and spawns an overlay on that btn
    /// </summary>
    private void SpawnOverlays() {
        // Get all abillities
        GameObject[] aInfo = GetChildren(this.gameObject);

        // Populate a new struct with info about the abillity (overlay prefab and ab cooldown)
        for (int i = 0; i < aInfo.Length; ++i) {
            //Debug.Log($"Rect position: {aInfo[i].GetComponent<RectTransform>().position}");
            Vector2 abPos = aInfo[i].transform.position;
            GameManagerScript.Abillities.Add(new Assets.AbillityInfo() {
                Overlay = Instantiate(overlayPref, abPos, Quaternion.identity),
                Cooldown = aInfo[i].GetComponent<AbInfo>().abillityCooldown,
                curCooldown = 0f,
                FraqScale = overlayPref.transform.localScale.y / 100f, // 1% of the overlay's scale, to scale it
                Dist2Center = CalcDist2Center(aInfo[i]),
                StartPos = aInfo[i].transform.position,
                AbillityName = aInfo[i].GetComponent<AbInfo>().abillityName,
            });
            //Debug.Log($"Found a new abillity button with cooldown of: {GameManagerScript.Abillities[i].Cooldown}");
        }
    }

    private float CalcDist2Center(GameObject obj) {
        return Mathf.Abs(obj.transform.position.y - obj.transform.GetChild(1).transform.position.y);
    }

    /// <summary>
    /// Returns an array of all the childen of a gameobject.
    /// </summary>
    private GameObject[] GetChildren(GameObject obj) {
        int count = obj.transform.childCount;
        GameObject[] temp = new GameObject[count];
        for (int i = 0; i < count; ++i) {
            temp[i] = obj.transform.GetChild(i).gameObject;
        }
        return temp;
    }

    private float ConvertPx2Units(float p) {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;

        return (p * ortho * 2f) / pixelH;
    }

    /// <summary>
    /// Enables cooldown for the abillity button with the specified name
    /// <param name="name"> The abillity name to enable cooldown for.</param>
    /// </summary>
    public void EnableCooldown(string name) {
        for (int i = 0; i < GameManagerScript.Abillities.Count; ++i) {
            if (GameManagerScript.Abillities[i].AbillityName == name && !GameManagerScript.Abillities[i].IsCooling) {
                //Debug.Log($"Enabled cooldown for: {GameManagerScript.Abillities[i].AbillityName}");
                GameManagerScript.Abillities[i].IsCooling = true;
            }
        }
    }
}
