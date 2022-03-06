using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndRemoveFromList : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Units")) {
            GameManagerScript.UnitsOnMap.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
