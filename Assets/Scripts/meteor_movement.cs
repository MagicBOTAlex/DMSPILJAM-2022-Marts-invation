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
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("meteor"))
        {
            Destroy(gameObject);
        }
    }
}
