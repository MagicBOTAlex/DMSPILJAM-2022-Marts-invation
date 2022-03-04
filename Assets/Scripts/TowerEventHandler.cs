using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEventHandler : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }
}
