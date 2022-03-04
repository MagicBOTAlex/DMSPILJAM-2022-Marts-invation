using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerScript : MonoBehaviour
{
    public GameObject BasePrefab;

    private void Start()
    {
        var scripts = GetComponentsInChildren<SpawnHereScript>();
        for (int i = 0; i < scripts.Length; i++)
        {
            var spawnedBase = Instantiate(BasePrefab, scripts[i].gameObject.transform.position, Quaternion.identity) as GameObject;

            spawnedBase.GetComponent<TowerIndexHolder>().TowerIndex = i;

            GameManagerScript.Bases.Add(new Assets.TowerInfo()
            {
                Object = spawnedBase,
                Type = scripts[i].BuildingType,
                TowerLevel = scripts[i].TowerStartLevel,
                UnitsInside = scripts[i].UnitsInside,
                IndexInList = i,
                MaxUnits = 100
            });

            Destroy(scripts[i].gameObject);
        }
    }
}
