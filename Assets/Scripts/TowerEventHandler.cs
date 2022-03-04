using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEventHandler : MonoBehaviour
{
    private void Start()
    {
        int towerLevel = GameManagerScript.Bases[GetComponent<TowerIndexHolder>().TowerIndex].TowerLevel;
        BuildingType type = GameManagerScript.Bases[GetComponent<TowerIndexHolder>().TowerIndex].Type;

        var sp = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case BuildingType.Player:
                sp.sprite = GameManagerScript.PlayerTowerSprites[towerLevel - 1];
                break;

            case BuildingType.Enemy:
                sp.sprite = GameManagerScript.EnemyTowerSprites[0];
                break;

            default:
                sp.sprite = GameManagerScript.NeutralTowerSprites[towerLevel - 1];
                break;
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
