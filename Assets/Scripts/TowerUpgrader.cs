using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrader : MonoBehaviour
{
    public int towerIndex = -1;
    private const float killDelay = 3f;
    private void Start() {
        StartCoroutine(KillMenu(killDelay));
    }
    private void OnMouseDown() {
        Upgrade();

    }

    private void Upgrade() {
        Debug.Log(towerIndex);
        // Upgrade tower level
        if (GameManagerScript.Towers[towerIndex].TowerLevel < 3)
            GameManagerScript.Towers[towerIndex].TowerLevel++;
        // Call DoubleStarter to apply changes
        GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
        
    }
    private IEnumerator KillMenu(float dl) {
        yield return new WaitForSecondsRealtime(dl);
        Destroy(gameObject);
    }
}
