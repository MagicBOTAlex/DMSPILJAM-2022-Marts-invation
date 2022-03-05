using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSendUnits : MonoBehaviour
{
    public bool SecondTowerClicked = false;
    public GameObject UnitPrefab;

    public bool firstClicked = false;
    public Sprite unitSprite;

    private void OnMouseDown()
    {
        firstClicked = !firstClicked;
        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = firstClicked;
    }

    private void Update()
    {
        if (SecondTowerClicked)
        {
            print("Sending units");
            StartCoroutine(SendUnits());
            SecondTowerClicked = false;
        }
    }

    IEnumerator SendUnits()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject unit = Instantiate(UnitPrefab, transform.position, Quaternion.identity) as GameObject;
            unit.GetComponent<SpriteRenderer>().sprite = unitSprite;
            var unitScript = unit.GetComponent<UnitScript>();
            unitScript.FromV = transform.position;
            unitScript.ToV = transform.GetChild(2).position;
            unitScript.Speed = 2;

            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
}
