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

    public void Upgrade() {
        Debug.Log($"Upgrading:  {towerIndex}");
        // Upgrade tower level
        if (GameManagerScript.Towers[towerIndex].TowerLevel == 1 && GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl2) {
            GameManagerScript.Towers[towerIndex].TowerLevel++;
            // Call DoubleStarter to apply changes
            GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2 && GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl3) {
            GameManagerScript.Towers[towerIndex].TowerLevel++;
            // Call DoubleStarter to apply changes
            GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
        }
        //Debug.Log($"Upgraded to {GameManagerScript.Towers[towerIndex].TowerLevel}");
        
    }
    private IEnumerator KillMenu(float dl) {
        yield return new WaitForSecondsRealtime(dl);
        Destroy(gameObject);
    }
}
