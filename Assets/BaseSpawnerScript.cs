using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerScript : MonoBehaviour
{
    public GameObject BasePrefab;

    private void Start()
    {
        foreach (var item in GetComponentsInChildren<SpawnHereScript>())
        {
            Instantiate(BasePrefab, item.gameObject.transform.position, Quaternion.identity);
            Destroy(item.gameObject);
        }
    }
}
