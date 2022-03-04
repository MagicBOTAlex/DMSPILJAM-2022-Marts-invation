using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance; // instance for accessing the non static variables

    // makes it visable in the inspector and is static var
    public List<TowerInfo> Towers_ = new List<TowerInfo>();
    public static List<TowerInfo> Towers { get { return instance.Towers_; } set { instance.Towers_ = value; } }
    public List<AbillityInfo> Abillities_ = new List<AbillityInfo>();
    public static List<AbillityInfo> Abillities { get { return instance.Abillities_; } set { instance.Abillities_ = value; } }

    // read the fucking name jeb_
    [Header("Settings")]
    public float GainUnitsDelay_ = 1f;
    public static float GainUnitsDelay { get { return instance.GainUnitsDelay_; } set { instance.GainUnitsDelay_ = value; } }

    [Header("Sprites")]
    public Sprite[] PlayerTowerSprites_;
    public static Sprite[] PlayerTowerSprites { get { return instance.PlayerTowerSprites_; } set { instance.PlayerTowerSprites_ = value; } }
    public Sprite[] NeutralTowerSprites_;
    public static Sprite[] NeutralTowerSprites { get { return instance.NeutralTowerSprites_; }  set { instance.NeutralTowerSprites_ = value; } }
    public Sprite[] EnemyTowerSprites_;
    public static Sprite[] EnemyTowerSprites { get { return instance.EnemyTowerSprites_; } set { instance.EnemyTowerSprites_ = value; } }

    private void Start()
    {
        // makes sure that there will only ever exist GameManagerScript.instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        // read the name you half faced monke
        StartCoroutine(StartGain());
    }

    // for every GainUnitsDelay_ seconds makes the towers gain units except neutual ones
    IEnumerator StartGain()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(GainUnitsDelay_);
            for (int i = 0; i < Towers.Count; i++)
            {
                if (Towers[i].Type != TowerType.Enemy && 
                    Towers[i].UnitsInside < Towers[i].MaxUnits + 1)
                {
                    Towers[i].UnitsInside++;
                }
            }
        }
    }
}
