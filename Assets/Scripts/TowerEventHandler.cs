using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerEventHandler : MonoBehaviour
{

    public GameObject upgradeMenu;
    private GameObject upgrademn;
    public float UMXOffset, UMYOffset;
    private void Start() => DoubleStarter();
    AudioManager auM;

    void Awake() {
        auM = FindObjectOfType<AudioManager>();
    }
    //private void OnEnable() => DoubleStarter();
    void Update() {
        auM.Play("UnitBloop");
    }
    public void DoubleStarter()
    {
        //Debug.Log(GetComponent<TowerIndexHolder>().TowerIndex);
        int towerLevel = GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].TowerLevel;
        TowerType type = GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].Type;

        var sp = GetComponent<SpriteRenderer>();
        switch (type)
        {
            //Trash
            case TowerType.Player:
                sp.sprite = GameManagerScript.PlayerTowerSprites[towerLevel - 1];
                break;

            case TowerType.Enemy:
                sp.sprite = GameManagerScript.EnemyTowerSprites[towerLevel - 1];
                break;

            default:
                sp.sprite = GameManagerScript.NeutralTowerSprites[towerLevel - 1];
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Hit!");
        //if (collision.gameObject.CompareTag("Units")) Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        //if (collision.gameObject.CompareTag("Towers")) Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        //try
        //{
        //    if (gameObject.CompareTag("meteor") || gameObject.CompareTag("shadow")) return;
        //    else if (gameObject != collision.gameObject.GetComponent<UnitScript>().To.Object) return;
        //}
        //catch { return; }
        if (gameObject.CompareTag("meteor") || gameObject.CompareTag("shadow")) {
            return;
        }
        try {
            if (gameObject != collision.gameObject.GetComponent<UnitScript>().To.Object) return;
        }
        catch {
            return;
        }

        GameManagerScript.UnitsOnMap.Remove(collision.gameObject);
        

        if (collision.GetComponent<UnitScript>().To.Type == TowerType.Enemy && collision.GetComponent<UnitScript>().Type == TowerType.Player)
        {
            //FindObjectOfType<AudioManager>().Play(ZhenAudioManager.audioClips[6].name);
            ZhenAudioManager.PlaySound(ZhenAudioManager.audioClips[6].name);
        }

        if ((collision.GetComponent<UnitScript>().To.Type == TowerType.Player && collision.GetComponent<UnitScript>().Type == TowerType.Player)||
            (collision.GetComponent<UnitScript>().To.Type == TowerType.Neutral && collision.GetComponent<UnitScript>().Type == TowerType.Player))
        {
            ZhenAudioManager.PlaySound("Troop Enter_Leave").volume = 0.5f;
        }
        if (collision.gameObject.GetComponent<UnitScript>().Type == collision.gameObject.GetComponent<UnitScript>().To.Type)
            GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside += collision.gameObject.GetComponent<UnitScript>().Damage;
        else
            GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside -= collision.gameObject.GetComponent<UnitScript>().Damage;

        //print($"Units inside: {GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside}");

        GameManagerScript.instance.CheckTower(collision.gameObject.GetComponent<UnitScript>().Type, GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex]);
        DoubleStarter();
        
        // BetterAudioManager.PlaySound(BetterAudioManager.audioClips[0]);
        //auM.Play("UnitBloop");
        Destroy(collision.gameObject);
    }

    private void OnMouseDown()
    {
        if (GameManagerScript.Selected[0] == null)
        {
            if (GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].Type != TowerType.Player) return;
            GameManagerScript.Selected[0] = gameObject;
        }
        else if (GameManagerScript.Selected[0] == gameObject)
        {
            GameManagerScript.Selected[0].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameManagerScript.Selected[0] = null;
        }
        else if (GameManagerScript.Selected[1] == null && GameManagerScript.Selected[0] != gameObject)
        {
            GameManagerScript.Selected[1] = gameObject;
        }

        GameManagerScript.instance.CheckSelected();
    }

    public void OnMouseEnter()
    {
        if (GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].Type != TowerType.Player) return;

        upgrademn = Instantiate(upgradeMenu, new Vector3(transform.position.x + UMXOffset, transform.position.y - UMYOffset, transform.position.z), upgradeMenu.transform.rotation);
        // Set the tower index in the new upgrader script so it knows which tower to upgrade
        int index = GetComponent<TowerIndexHolder>().TowerIndex;
        upgrademn.GetComponent<TowerUpgrader>().towerIndex = index;
        upgrademn.GetComponent<TowerUpgrader>().UpdateSprite();
        upgrademn.GetComponent<TowerUpgrader>().mouseOver = true;

        if (GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].TowerLevel == 3)
        {
            transform.GetChild(0).transform.localScale = GameManagerScript.SelectedLvl3LocalScaleStretch;
        }
        transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        if (GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].Type != TowerType.Player) return;

        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        upgrademn.GetComponent<TowerUpgrader>().UpdateSprite();
        StartCoroutine(upgrademn.GetComponent<TowerUpgrader>().KillMenu(0f));
        upgrademn.GetComponent<TowerUpgrader>().mouseOver = false;
    }
}
