using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbillityCooldDown : MonoBehaviour
{
    public GameObject overlayPref;

    private void Awake() {
        if (overlayPref == null) {
            Destroy(this);
        }
    }

    private void Start() {
        // Get and spawn the overlays needed for all the abillities
        SpawnOverlays();
    }
    private void Update() {
        // Update every abillity overlay
        for (int i = 0; i < GameManagerScript.Abillities.Count; ++i) {
            if (GameManagerScript.Abillities[i].curCooldown < GameManagerScript.Abillities[i].Cooldown) { // While cooling down abillity    
                GameManagerScript.Abillities[i].curCooldown += Time.deltaTime;
                // Get the percentage of how much the overlay should cover of the buttton
                float distFromCompl = 1 - GameManagerScript.Abillities[i].Cooldown / GameManagerScript.Abillities[i].curCooldown;

            }
        }
    }

    /// <summary>
    /// Gets all the overlays needed for all abillity buttons, and spawns an overlay on that btn
    /// </summary>
    private void SpawnOverlays() {
        // Get all abillities
        //AbInfo[] aInfo = GetComponentsInChildren<AbInfo>();
        GameObject[] aInfo = GetChildren(this.gameObject);

        // Populate a new struct with info about the abillity (overlay prefab and ab cooldown)
        for (int i = 0; i < aInfo.Length; ++i) {
            Vector2 abPos = aInfo[i].transform.position;
            GameManagerScript.Abillities.Add(new Assets.AbillityInfo() {
                Overlay = Instantiate(overlayPref, abPos, Quaternion.identity),
                Cooldown = aInfo[i].GetComponent<AbInfo>().abillityCooldown,
                curCooldown = 0f
            });
            //Debug.Log($"Found a new abillity button with cooldown of: {GameManagerScript.Abillities[i].Cooldown}");
        }
    }

    private GameObject[] GetChildren(GameObject obj) {
        int count = obj.transform.childCount;
        GameObject[] temp = new GameObject[count];
        for (int i = 0; i < count; ++i) {
            temp[i] = obj.transform.GetChild(i).gameObject;
        }
        return temp;
    }
}
