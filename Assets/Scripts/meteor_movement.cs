using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_movement : MonoBehaviour
{

    public float speed;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("shadow").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetBool("explode") != true)
        {
            if (gameObject == null)
            {
                GetComponent<Animator>().SetBool("explode", false);
            }
            if (target != null)
            {
                transform.up = (target.position - transform.position) * -1f;
            }
            try
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            catch
            {
                try
                {
                    target = GameObject.FindGameObjectWithTag("shadow").GetComponent<Transform>();
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }
                catch
                {
                    //Runs when no shadow exists
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("shadow"))
        {
            StartCoroutine(destroy_self());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            StartCoroutine(destroy_self());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("meteor"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator destroy_self()
    {
        GetComponent<Animator>().SetBool("explode", true);
        var rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        yield return new WaitForSecondsRealtime(0.45f);
        Destroy(gameObject);
    }
}
