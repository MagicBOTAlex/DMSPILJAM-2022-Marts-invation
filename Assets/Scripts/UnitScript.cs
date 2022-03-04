using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public Vector3 From;
    public Vector3 To;

    Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.MoveTowards(From, To, 1) * Speed;
    }
}
