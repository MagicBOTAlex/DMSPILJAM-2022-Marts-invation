using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : MonoBehaviour
{
    // Spawn 1 unit pr. sec
    private float spawnRate = 1f;
    private uint units = 0;
    [SerializeField]
    private GameObject unit;

    private static float spawnCooldown = 0f;

    private void Awake() {
    
    }
    private void Start() {
        
    }

    private void FixedUpdate() {
        // Spawn units
        HandleUnits();
    }

     /// <summary>
    /// Handles spawning units each physics update 
    /// </summary>
    private void HandleUnits() {
        spawnCooldown += Time.fixedDeltaTime;
        if (spawnCooldown >= spawnRate) {
            // Should spawn a unit
            SpawnUnit();
        }
    }

    /// <summary>
    /// Method for spawning a unit, inside the hub
    /// </summary>
    private void SpawnUnit() {
        
    }
}
