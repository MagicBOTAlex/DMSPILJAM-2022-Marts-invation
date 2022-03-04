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

            GameManagerScript.Bases.Add(new Assets.TowerInfo()
            {
                Object = spawnedBase,
                Type = scripts[i].BuildingType,
                TowerLevel = 1,
                UnitsInside = scripts[i].UnitsInside
            });

            Destroy(scripts[i].gameObject);
        }
    }
}
