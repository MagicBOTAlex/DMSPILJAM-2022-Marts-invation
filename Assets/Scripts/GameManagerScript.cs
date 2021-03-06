using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance; // instance for accessing the non static variables

    // makes it visable in the inspector and is static var
    public List<TowerInfo> Towers_ = new List<TowerInfo>();
    public static List<TowerInfo> Towers { get { return instance.Towers_; } set { instance.Towers_ = value; } }
    public List<AbillityInfo> Abillities_ = new List<AbillityInfo>();
    public static TowerInfo[] PlayerTowers { get { return instance.Towers_.Where(x => x.Type == TowerType.Player).ToArray(); }
        set
        {
            for (int i = 0; i < value.Length; i++)
            {
                instance.Towers_[value[i].IndexInList] = value[i];
            }
        }
    }
    public static TowerInfo[] NeutralTowers { get { return instance.Towers_.Where(x => x.Type == TowerType.Neutral).ToArray(); } set 
        {
            for (int i = 0; i < value.Length; i++)
            {
                instance.Towers_[value[i].IndexInList] = value[i];
            }
        } 
    }
    public static TowerInfo[] EnemyTowersRandom { get { return instance.Towers_.Where(x => x.Type == TowerType.Enemy).ToArray(); } 
        set 
        {
            for (int i = 0; i < value.Length; i++)
            {
                instance.Towers_[value[i].IndexInList] = value[i];
            }
        } 
    }

    public static List<AbillityInfo> Abillities { get { return instance.Abillities_; } set { instance.Abillities_ = value; } }
    public GameObject[] Seleted_ = new GameObject[2];
    public static GameObject[] Selected { get { return instance.Seleted_; } set { instance.Seleted_ = value; } }
    public List<GameObject> UnitsOnMap_;
    public static List<GameObject> UnitsOnMap { get { return instance.UnitsOnMap_; } set { instance.UnitsOnMap_ = value; } }
    public int PlayerUnitsPending_ = 0;
    public static int PlayerUnitsPending { get { return instance.PlayerUnitsPending_; } set { instance.PlayerUnitsPending_ = value; } }
    public int EnemyUnitsPending_ = 0;
    public static int EnemyUnitsPending { get { return instance.EnemyUnitsPending_; } set { instance.EnemyUnitsPending_ = value; } }

    public static int UnitsNeededForLvl2 = 20;
    public static int UnitsNeededForLvl3 = 50;

    // read the fucking text jeb_
    [Header("Settings")]
    public float GainUnitsDelay_ = 1f;
    public static float GainUnitsDelay { get { return instance.GainUnitsDelay_; } set { instance.GainUnitsDelay_ = value; } }
    public float UnitSpeed_ = 1f;
    public static float UnitSpeed { get { return instance.UnitSpeed_; } set { instance.UnitSpeed_ = value;} }
    public float UnitSpawnDelay_ = 0.1f;
    public static float UnitSpawnDelay { get { return instance.UnitSpawnDelay_; } set { instance.UnitSpawnDelay_ = value; } }
    public static Vector3 SelectedLvl3LocalScaleStretch = new Vector3(1.3f, 1f, 1f);
    public float UnitSpawnOffset = 0.5f;

    [Header("Sprites and prefabs")]
    public Sprite[] PlayerTowerSprites_;
    public static Sprite[] PlayerTowerSprites { get { return instance.PlayerTowerSprites_; } set { instance.PlayerTowerSprites_ = value; } }
    public Sprite[] NeutralTowerSprites_;
    public static Sprite[] NeutralTowerSprites { get { return instance.NeutralTowerSprites_; }  set { instance.NeutralTowerSprites_ = value; } }
    public Sprite[] EnemyTowerSprites_;
    public static Sprite[] EnemyTowerSprites { get { return instance.EnemyTowerSprites_; } set { instance.EnemyTowerSprites_ = value; } }
    public static bool IsPlayerOnMap = false;
    public GameObject UnitPrefab;

    public Sprite[] PlayerUnitSprite;
    public Sprite[] EnemyUnitSprite;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    GameObject spawnedUnitsHolder;

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

        spawnedUnitsHolder = new GameObject("UnitHolder");

        AudioListener.volume = PlayerPrefs.GetFloat("Volume");

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
                if (Towers[i].Type != TowerType.Neutral && 
                    Towers[i].UnitsInside < Towers[i].MaxUnits + 1)
                {
                    Towers[i].UnitsInside += Towers[i].TowerLevel;
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

        from.UnitsInside -= amount;

        StartCoroutine(StartSending(from, to, amount));
        return true;
    }

    IEnumerator StartSending(TowerInfo from, TowerInfo to, int amount)
    {
        var unitSprite = (from.Type == TowerType.Player) ? PlayerUnitSprite : EnemyUnitSprite;

        if (from.Type == TowerType.Player)
            PlayerUnitsPending += amount;
        else
            EnemyUnitsPending += amount;

        var TypeHolder = from.Type;

        for (int i = 0; i < amount; i++)
        {
            var unit = Instantiate(UnitPrefab, from.Object.transform.position + new Vector3(Random.Range(-UnitSpawnOffset, UnitSpawnOffset), Random.Range(-UnitSpawnOffset, UnitSpawnOffset)), Quaternion.identity, spawnedUnitsHolder.transform);
            var unitScript = unit.GetComponent<UnitScript>();

            Sprite selectedSprite = (i % 10 == 0) ? unitSprite[1] : unitSprite[0];
            if (TypeHolder == TowerType.Enemy)
                selectedSprite = (i % 20 == 0) ? unitSprite[2] : selectedSprite;

            unit.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            unit.name = i.ToString();
            UnitsOnMap.Add(unit);

            unitScript.From = from;
            unitScript.Type = TypeHolder;
            unitScript.To = to;
            unitScript.Speed = UnitSpeed_;

            if (TypeHolder == TowerType.Player)
            {
                PlayerUnitsPending--;
                ZhenAudioManager.PlaySound("Troop Enter_Leave").volume = 0.5f;
            }
            else
            {
                EnemyUnitsPending--;
            }

                //from.UnitsInside--;
                yield return new WaitForSecondsRealtime(UnitSpawnDelay_);
        }
    }

    public void CheckSelected()
    {
        if (Selected[0] == null) return;
        else Selected[0].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;

        if (Selected[1] == null) return;

        //print("Sending units");
        SendUnits(Towers_[Selected[0].GetComponent<TowerIndexHolder>().TowerIndex], Towers_[Selected[1].GetComponent<TowerIndexHolder>().TowerIndex], Towers_[Selected[0].GetComponent<TowerIndexHolder>().TowerIndex].UnitsInside);

        Selected[0].gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < Selected.Length; i++)
        {
            Selected[i] = null;
        }
    }

    /// <summary>
    /// Checks if the units inside the target tower is negative or not. Then converts the tower to the oppisite
    /// </summary>
    public void CheckTower(TowerType from, TowerInfo to)
    {
        if (Towers[to.IndexInList].UnitsInside < 0) ConvertTower(from, to);
        //print(Towers[to.IndexInList].UnitsInside.ToString());
    }

    public void ConvertTower(TowerType from, TowerInfo to) 
    {
        if (to.Type != TowerType.Neutral) 
            Towers[to.IndexInList].TowerLevel = 1;

        Towers[to.IndexInList].UnitsInside = 0;

        if (to.Type == TowerType.Neutral)
        {
            Towers[to.IndexInList].Type = from;
        }
        else
        {
            Towers[to.IndexInList].Type = (from == TowerType.Player) ? TowerType.Player : TowerType.Enemy;
            if (from == TowerType.Player)
            {
                ZhenAudioManager.PlaySound("PlayerTakeTower").volume = 0.5f;
            }
            else
            {
                ZhenAudioManager.PlaySound("EnemyTakeTower").volume = 0.5f;
            }
        }

        CheckIfWin();
    }


    bool IsChanging = false;
    void CheckIfWin()
    {
        if (PlayerTowers.Length == 0 &&
            PlayerUnitsPending == 0 &&
            UnitsOnMap.Where(x=>x.GetComponent<UnitScript>().From.Type == TowerType.Player).Count() == 0)
        {
            LoseScreen.SetActive(true);
            if (!IsChanging)
            {
                IsChanging = true;
                StartCoroutine(ChangeToMenu());
            }
        }

        if (EnemyTowersRandom.Length == 0 &&
            EnemyUnitsPending == 0 &&
            UnitsOnMap.Where(x => x.GetComponent<UnitScript>().From.Type == TowerType.Enemy).Count() == 0)
        {
            WinScreen.SetActive(true);
            if (!IsChanging)
            {
                IsChanging = true;
                StartCoroutine(ChangeToMenu());
            }
        }
    }

    public RectTransform fader;
    IEnumerator ChangeToMenu()
    {
        instance = null;

        yield return new WaitForSecondsRealtime(3);

        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            SceneManager.LoadScene("Menu");
        });
    }
}
