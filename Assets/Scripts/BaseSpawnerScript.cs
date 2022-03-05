using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerScript : MonoBehaviour
{
    public GameObject BasePrefab;
    public GameObject UDPref;
    private void Start()
    {
        var scripts = GetComponentsInChildren<SpawnHereScript>();
        for (int i = 0; i < scripts.Length; i++)
        {
            var spawnedBase = Instantiate(BasePrefab, scripts[i].gameObject.transform.position, Quaternion.identity) as GameObject;

            spawnedBase.transform.SetParent(gameObject.transform);

            spawnedBase.GetComponent<TowerIndexHolder>().TowerIndex = i;

            spawnedBase.name = i.ToString();

            GameManagerScript.Towers.Add(new Assets.TowerInfo()
            {
                Object = spawnedBase,
                Type = scripts[i].Type,
                TowerLevel = scripts[i].TowerStartLevel,
                UnitsInside = scripts[i].UnitsInside,
                IndexInList = i,
                MaxUnits = 100
            });

            // Spawn unit displayer
            var spawnedUD = Instantiate(UDPref, scripts[i].gameObject.transform.position, Quaternion.identity)  as GameObject;
            spawnedUD.GetComponent<UnitDisplayer>().towerIndex = i;

            Destroy(scripts[i].gameObject);
        }
    }
}
