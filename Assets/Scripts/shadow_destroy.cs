using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_destroy : MonoBehaviour
{
    public GameObject meteor;

    private GameObject other_obj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var other_obj = other;
        if (other.CompareTag("meteor"))
        {
            StartCoroutine(destroy_self());
        }
        else if (other.CompareTag("shadow"))
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator destroy_self()
    {
        meteor.GetComponent<Animator>().SetBool("explode", true);
        yield return new WaitForSecondsRealtime(1);
        Destroy(other_obj.gameObject);
    }
}
