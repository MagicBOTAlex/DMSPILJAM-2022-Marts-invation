using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerEventHandler : MonoBehaviour
{

    public GameObject upgradeMenu;
    private void Start() => DoubleStarter();
    //private void OnEnable() => DoubleStarter();

    public void DoubleStarter()
    {
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
                sp.sprite = GameManagerScript.NeutralTowerSprites[0];
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Hit!");
        //if (collision.gameObject.CompareTag("Units")) Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        //if (collision.gameObject.CompareTag("Towers")) Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        if (gameObject != collision.gameObject.GetComponent<UnitScript>().To.Object) return;

        if (collision.gameObject.GetComponent<UnitScript>().From.Type == TowerType.Player)
            GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside += collision.gameObject.GetComponent<UnitScript>().Damage;
        if (collision.gameObject.GetComponent<UnitScript>().From.Type == TowerType.Enemy)
            GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside -= collision.gameObject.GetComponent<UnitScript>().Damage;

        Destroy(collision.gameObject);
    }

    private void OnMouseDown()
    {
        if (GameManagerScript.Selected[0] == null)
        {
            GameManagerScript.Selected[0] = gameObject;
        }

        if (GameManagerScript.Selected[1] == null && GameManagerScript.Selected[0] != gameObject)
        {
            GameManagerScript.Selected[1] = gameObject;
        }

        GameManagerScript.instance.CheckSelected();
    }

    public void OnMouseEnter()
    {
        GameObject upgrademn = Instantiate(upgradeMenu, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), upgradeMenu.transform.rotation);
        // Set the tower index in the new upgrader script so it knows which tower to upgrade
        upgradeMenu.GetComponent<TowerUpgrader>().towerIndex = GetComponent<TowerIndexHolder>().TowerIndex;
        transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }
}
