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
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("shadow"))
        {
            Destroy(other.gameObject);
            StartCoroutine(destroy_self());
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            StartCoroutine(destroy_self());
        }
        else if (other.CompareTag("meteor"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator destroy_self()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Animator>().SetBool("explode", true);
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
}
