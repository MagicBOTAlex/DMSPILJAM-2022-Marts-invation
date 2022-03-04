using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbillityCooldDown : MonoBehaviour
{
    public GameObject overlayPref;
    private List<GameObject> abillities = new List<GameObject>();

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

    }

    /// <summary>
    /// Gets all the overlays needed for all abillity buttons, and spawns an overlay on that btn
    /// </summary>
    private async void SpawnOverlays() {
        // Get all abillities
        AbillityInfo[] aInfo = GetComponentsInChildren<AbillityInfo>();
        
        // Populate a new struct with info about the abillity
        for (int i = 0; i < aInfo.Length; ++i) {
            
        }
    }
}
