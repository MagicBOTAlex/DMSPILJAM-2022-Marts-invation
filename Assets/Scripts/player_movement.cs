using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float MinSpeed;
    public float Acceleration;
    public float Deceleration;

    float horizontal;
    float vertical;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Speed = Mathf.Min(Speed + Acceleration * Time.deltaTime, MaxSpeed);
        }
        else
        {
            Speed = Mathf.Max(Speed - Deceleration * Time.deltaTime, MinSpeed);
        }
        body.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }

}