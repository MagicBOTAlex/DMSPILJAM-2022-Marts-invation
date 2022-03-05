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
            transform.right = target.position - transform.position;
            transform.right += new Vector3(5f, 5f, 5f);
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
            target = GameObject.FindGameObjectWithTag("shadow").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
    }
}
