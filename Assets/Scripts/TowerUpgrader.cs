using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrader : MonoBehaviour
{
    public int towerIndex = -1;
    public const float killDelay = 3f;
    public Sprite upgrade;
    public bool mouseOver;
    public Sprite nonUpgrade;
    SpriteRenderer sr;


    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        //StartCoroutine(KillMenu(killDelay));
    }

    private void FixedUpdate() {
        
            UpdateSprite();
    }
    private void OnMouseDown() {
        Upgrade();
        UpdateSprite();

    }

    private void OnMouseEnter() {
        mouseOver = true;
    }

    private void OnMouseExit() {
        mouseOver = false;
    }

    public void Upgrade() {
        // Upgrade tower level
        if (GameManagerScript.Towers[towerIndex].TowerLevel == 1 && GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl2) {
            GameManagerScript.Towers[towerIndex].TowerLevel++;
            // Call DoubleStarter to apply changes
            GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
            GameManagerScript.Towers[towerIndex].UnitsInside -= GameManagerScript.UnitsNeededForLvl2;
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2 && GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl3) {
            GameManagerScript.Towers[towerIndex].TowerLevel++;
            // Call DoubleStarter to apply changes
            GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
            GameManagerScript.Towers[towerIndex].UnitsInside -= GameManagerScript.UnitsNeededForLvl3;
        }

    }
    public IEnumerator KillMenu(float dl) {
        yield return new WaitForSecondsRealtime(dl);
        Destroy(gameObject);
    }
    public void UpdateSprite() {
        if (GameManagerScript.Towers[towerIndex].TowerLevel == 1) {
            if (GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl2) {
                Debug.Log($"Sufficient Amount of units inside for upgrade: inside {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = upgrade;
            }
            else {
                Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = nonUpgrade;
            }
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2) {
            if (GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl3) {
                Debug.Log($"Sufficient Amount of units inside for upgrade: inside {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = upgrade;
            }
            else {
                Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = nonUpgrade;
            }
        }
        else {
            Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
            sr.sprite = nonUpgrade;
        }
    }
}
