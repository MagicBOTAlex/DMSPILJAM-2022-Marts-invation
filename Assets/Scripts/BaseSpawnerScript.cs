using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerScript : MonoBehaviour
{
    public GameObject BasePrefab;
    public GameObject UDPref;
    public float UDXOffset, UDYOffset;
    private void Start()
    {
        var scripts = GetComponentsInChildren<SpawnHereScript>();
        for (int i = 0; i < scripts.Length; i++)
        {
            var spawnedBase = Instantiate(BasePrefab, scripts[i].gameObject.transform.position, Quaternion.identity) as GameObject;

            spawnedBase.transform.SetParent(gameObject.transform);

            spawnedBase.GetComponent<TowerIndexHolder>().TowerIndex = i;

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
            var spawnedUD = Instantiate(UDPref, new Vector3(scripts[i].gameObject.transform.position.x - UDXOffset, scripts[i].gameObject.transform.position.y + UDYOffset, scripts[i].gameObject.transform.position.z), Quaternion.identity)  as GameObject;
            spawnedUD.GetComponent<UnitDisplayer>().towerIndex = i;

            Destroy(scripts[i].gameObject);
        }
    }
}
