using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSecondTowerClick : MonoBehaviour
{
    public Sprite PlayerTowerPrefab;

    private void OnMouseDown()
    {
        if (transform.parent.GetComponent<TutorialSendUnits>().firstClicked)
            transform.parent.GetComponent<TutorialSendUnits>().SecondTowerClicked = true;
    }

    private void FixedUpdate()
    {
        if (GetComponent<DestroyOnTrigger>().ObjectsDestroyed > 15)
            GetComponent<SpriteRenderer>().sprite = PlayerTowerPrefab;
    }
}
