using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEventHandler : MonoBehaviour
{
    private void Start()
    {
        int towerLevel = GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].TowerLevel;
        TowerType type = GameManagerScript.Towers[GetComponent<TowerIndexHolder>().TowerIndex].Type;

        var sp = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case TowerType.Player:
                sp.sprite = GameManagerScript.PlayerTowerSprites[towerLevel - 1];
                break;

            case TowerType.Enemy:
                sp.sprite = GameManagerScript.EnemyTowerSprites[0];
                break;

            default:
                sp.sprite = GameManagerScript.NeutralTowerSprites[towerLevel - 1];
                break;
        }
    }

    private void OnMouseDown()
    {
        if (GameManagerScript.Selected[0] == null)
        {
            GameManagerScript.Selected[0] = gameObject;
            return;
        }

        if (GameManagerScript.Selected[1] == null)
        {
            GameManagerScript.Selected[1] = gameObject;
            return;
        }
    }

    public void OnMouseEnter()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }
}