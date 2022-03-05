using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float Speed; //Should be 2
    public float MaxSpeed; //Should be 2
    public float MinSpeed; //Should be 0
    public float Acceleration; //Should be high(3 to 6 ish)
    public float Deceleration; //Should be high(5 to 8 ish)

    float horizontal;
    float vertical;

    string last_direction;

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

            //Shit works, dont complain
            if (Input.GetKey(KeyCode.W)) { last_direction = "Up"; }
            if (Input.GetKey(KeyCode.A)) { last_direction = "Left"; }
            if (Input.GetKey(KeyCode.S)) { last_direction = "Down"; }
            if (Input.GetKey(KeyCode.D)) { last_direction = "Right"; }

            //Diagonal
            if (body.velocity == new Vector2(Speed * -1f, Speed)) { last_direction = "UpLeft"; }
            if (body.velocity == new Vector2(Speed, Speed)) { last_direction = "UpRight"; }
            if (body.velocity == new Vector2(Speed * -1f, Speed * -1f)) { last_direction = "LeftDown"; }
            if (body.velocity == new Vector2(Speed, Speed * -1f)) { last_direction = "DownRight"; }



            body.velocity = new Vector2(horizontal * Speed, vertical * Speed);

        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && Speed != 0)
        {
            Speed = Mathf.Max(Speed - Deceleration * Time.deltaTime, MinSpeed);

            if (last_direction == "Up") { body.velocity = new Vector2(0f, Speed); }
            if (last_direction == "Left") { body.velocity = new Vector2(Speed * -1f, 0f); }
            if (last_direction == "Down") { body.velocity = new Vector2(0f, Speed * -1f); }
            if (last_direction == "Right") { body.velocity = new Vector2(Speed, 0f); }

            //Diagonal
            if (last_direction == "UpLeft") { body.velocity = new Vector2(Speed * -1f, Speed); }
            if (last_direction == "UpRight") { body.velocity = new Vector2(Speed, Speed); }
            if (last_direction == "LeftDown") { body.velocity = new Vector2(Speed * -1f, Speed * -1f); }
            if (last_direction == "DownRight") { body.velocity = new Vector2(Speed, Speed * -1f); }
        }
        else
        {
            Speed = Mathf.Max(Speed - Deceleration * Time.deltaTime, MinSpeed);
        }

    }

}