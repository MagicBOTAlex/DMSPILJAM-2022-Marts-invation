using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public Vector2 From;
    public Vector2 To;
    public TowerInfo SentFrom;

    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dir = -(From - To);
        transform.position += new Vector3(1f * dir.x, 1f * dir.y, 1f)* Speed * Time.fixedDeltaTime;
        //rb.velocity = Vector2.MoveTowards(From, To, Mathf.Infinity);
    }
}
