using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrader : MonoBehaviour
{
    private const float killDelay = 3f;
    private void Start() {
        StartCoroutine(KillMenu(killDelay));
    }
    private void OnMouseDown() {
        Upgrade();

    }

    private void Upgrade() {
        // Get the current tower index

        // Upgrade tower level

        // Call DoubleStarter to apply changes
        
    }
    private IEnumerator KillMenu(float dl) {
        yield return new WaitForSecondsRealtime(dl);
        Destroy(gameObject);
    }
}
