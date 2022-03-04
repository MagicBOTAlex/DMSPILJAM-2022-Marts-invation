using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;


    public List<TowerInfo> Bases_ = new List<TowerInfo>();
    public static List<TowerInfo> Bases { get { return instance.Bases_; } set { instance.Bases_ = value; } }
    public List<AbillityInfo> Abillities_ = new List<AbillityInfo>();
    public static List<AbillityInfo> Abillities { get { return instance.Abillities_; } set { instance.Abillities_ = value; } }

    [Header("Settings")]
    public float GainUnitsDelay_ = 1f;
    public static float GainUnitsDelay { get { return instance.GainUnitsDelay_; } set { instance.GainUnitsDelay_ = value; } }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        StartCoroutine(StartGain());
    }

    IEnumerator StartGain()
    {
        while (true)
        {
            yield return new WaitForSeconds(GainUnitsDelay_);
            for (int i = 0; i < Bases.Count; i++)
            {
                if (Bases[i].Type != BuildingType.Enemy && 
                    Bases[i].UnitsInside < Bases[i].MaxUnits + 1)
                {
                    Bases[i].UnitsInside++;
                }
            }
        }
    }
}
