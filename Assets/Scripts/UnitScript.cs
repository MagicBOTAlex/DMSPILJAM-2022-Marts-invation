using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public Vector2 From;
    public Vector2 To;

    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.MoveTowards(To, From, Speed);
    }
}
