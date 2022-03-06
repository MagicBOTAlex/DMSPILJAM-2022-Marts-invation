using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("shadow"))
        {
            Destroy(other.gameObject);
        }
    }
}
