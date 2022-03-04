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
    public GameObject[] Seleted_ = new GameObject[2];
    public static GameObject[] Selected { get { return instance.Seleted_; } set { instance.Seleted_ = value; } }
    public float GainUnitsDelay_ = 1f;
    public static float GainUnitsDelay { get { return instance.GainUnitsDelay_; } set { instance.GainUnitsDelay_ = value; } }
    public float UnitSpeed_ = 1f;
    public static float UnitSpeed { get { return instance.UnitSpeed_; } set { instance.UnitSpeed_ = value;} }
    public float UnitSpawnDelay_ = 0.1f;
    public static float UnitSpawnDelay { get { return instance.UnitSpawnDelay_; } set { instance.UnitSpawnDelay_ = value; } }

    [Header("Sprites and prefabs")]
    public Sprite[] PlayerTowerSprites_;
    public static Sprite[] PlayerTowerSprites { get { return instance.PlayerTowerSprites_; } set { instance.PlayerTowerSprites_ = value; } }
    public Sprite[] NeutralTowerSprites_;
    public static Sprite[] NeutralTowerSprites { get { return instance.NeutralTowerSprites_; }  set { instance.NeutralTowerSprites_ = value; } }
    public Sprite[] EnemyTowerSprites_;
    public static Sprite[] EnemyTowerSprites { get { return instance.EnemyTowerSprites_; } set { instance.EnemyTowerSprites_ = value; } }

    public GameObject UnitPrefab;

    public Sprite PlayerUnitSprite;
    public Sprite EnemyUnitSprite;

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

    /// <summary>
    /// Sends a certain amount of units from a tower to another
    /// </summary>
    /// <param name="from">Where the units shall be drawn from</param>
    /// <param name="to">Where the units shall endup at</param>
    /// <param name="amount">How many units shall be sent</param>
    /// <returns>True if sufficiant amount in "from" tower</returns>
    public bool SendUnits(TowerInfo from, TowerInfo to, int amount)
    {
        if (from.UnitsInside < amount) return false;
        if (from.Type == TowerType.Neutral) return false;

        StartCoroutine(StartSending(from, to, amount));
        return true;
    }

    IEnumerator StartSending(TowerInfo from, TowerInfo to, int amount)
    {
        var unitSprite = (from.Type == TowerType.Player) ? PlayerUnitSprite : EnemyUnitSprite;

        for (int i = 0; i < amount; i++)
        {
            var unit = Instantiate(UnitPrefab, from.Object.transform.position, Quaternion.identity) as GameObject;
            var unitScript = unit.GetComponent<UnitScript>();

            unit.GetComponent<SpriteRenderer>().sprite = unitSprite;

            unitScript.From = from.Object.transform.position;
            unitScript.To = to.Object.transform.position;
            unitScript.Speed = UnitSpeed_;

            yield return new WaitForSecondsRealtime(UnitSpawnDelay_);
        }
    }
}
