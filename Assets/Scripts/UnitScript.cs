using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 1f;
    public TowerInfo From;
    public TowerInfo To;

    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dir = -(From.Object.transform.position - To.Object.transform.position);
        transform.position += new Vector3(1f * dir.x, 1f * dir.y, 1f).normalized * (Speed / 100);
        //rb.velocity = Vector2.MoveTowards(From, To, Mathf.Infinity);
    }
}
