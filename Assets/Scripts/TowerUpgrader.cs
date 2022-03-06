using System;
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
    public TextMesh speedText;
    public TextMesh costText;
    SpriteRenderer sr;


    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        speedText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
    }
    private void Start() {
        //StartCoroutine(KillMenu(killDelay));
    }

    private void FixedUpdate() {
        
        if (mouseOver)
        {
            UpdateSprite();
            UpdateText();
        }
        else {
            sr.enabled = false;
        }
    }

    /// <summary>
    /// Update cost and units pr s text
    /// </summary>
    private void UpdateText()
    {
        // Cost and units
        string cost = "";
        string unitsPrS = "";
        if (GameManagerScript.Towers[towerIndex].TowerLevel == 1) {
            cost = "Cost: " + GameManagerScript.UnitsNeededForLvl2.ToString();
            unitsPrS = "2 units/s";
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2) {
            cost = "Cost: " + GameManagerScript.UnitsNeededForLvl3.ToString();
            unitsPrS = "3 units/s";
        }
        else {
            costText.gameObject.SetActive(false);
            speedText.gameObject.SetActive(false);
            return;
        }

        costText.gameObject.SetActive(true);
        speedText.gameObject.SetActive(true);
        costText.text = cost;
        speedText.text = unitsPrS;

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

            ZhenAudioManager.PlaySound("UpgradeTower");
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2 && GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl3) {
            GameManagerScript.Towers[towerIndex].TowerLevel++;
            // Call DoubleStarter to apply changes
            GameManagerScript.Towers[towerIndex].Object.GetComponent<TowerEventHandler>().DoubleStarter();
            GameManagerScript.Towers[towerIndex].UnitsInside -= GameManagerScript.UnitsNeededForLvl3;

            ZhenAudioManager.PlaySound("UpgradeTower");
        }

    }
    public IEnumerator KillMenu(float dl) {
        bool isDestroyed = false;
        do {
            yield return new WaitForSecondsRealtime(dl);
            if (!mouseOver) {
                isDestroyed = true;
                Destroy(gameObject);
            }
        } while (!isDestroyed);
        
    }
    public void UpdateSprite() {
        if (GameManagerScript.Towers[towerIndex].TowerLevel != 3) {
            sr.enabled = true;
        }
        if (GameManagerScript.Towers[towerIndex].TowerLevel == 1) {
            if (GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl2) {
                //Debug.Log($"Sufficient Amount of units inside for upgrade: inside {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = upgrade;
            }
            else {
                //Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = nonUpgrade;
            }
        }
        else if (GameManagerScript.Towers[towerIndex].TowerLevel == 2) {
            if (GameManagerScript.Towers[towerIndex].UnitsInside >= GameManagerScript.UnitsNeededForLvl3) {
                //Debug.Log($"Sufficient Amount of units inside for upgrade: inside {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = upgrade;
            }
            else {
                //Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
                sr.sprite = nonUpgrade;
            }
        }
        else {
            //Debug.Log($"Not enough units to upgrade!: {GameManagerScript.Towers[towerIndex].UnitsInside}");
            sr.sprite = nonUpgrade;
        }
    }
}
