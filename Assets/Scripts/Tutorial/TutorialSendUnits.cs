using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSendUnits : MonoBehaviour
{
    public bool SecondTowerClicked = false;
    public GameObject UnitPrefab;
    public int firstUnits = 20;
    public int secondsUnits = 0;
    public bool firstClicked = false;
    public Sprite unitSprite;

    private void OnMouseDown()
    {
        firstClicked = !firstClicked;
        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = firstClicked;
    }

    bool hasSent = false;
    private void Update()
    {
        if (SecondTowerClicked && !hasSent)
        {
            print("Sending units");
            StartCoroutine(SendUnits());
            SecondTowerClicked = false;
            hasSent = true;
        }
    }

    IEnumerator SendUnits()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject unit = Instantiate(UnitPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), Quaternion.identity) as GameObject;
            unit.GetComponent<SpriteRenderer>().sprite = unitSprite;
            var unitScript = unit.GetComponent<UnitScript>();
            unitScript.FromV = transform.position;
            unitScript.ToV = transform.GetChild(3).position;
            unitScript.Speed = 2;
            firstUnits--;

            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
}
