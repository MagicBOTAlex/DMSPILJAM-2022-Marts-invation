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
    public TowerType Type;

    public Vector2 FromV;
    public Vector2 ToV;

    Rigidbody2D rb;

    private void Start()
    {
        //BetterAudioManager.PlaySound();

        if (From != null)
        {
            Type = From.Type;
            //print($"{From.Type} {Type}");
        }
    }

    private void FixedUpdate()
    {
        if (From != null)
        {
            Vector2 dir = -(transform.position - To.Object.transform.position);
            transform.position += new Vector3(1f * dir.x, 1f * dir.y, 1f).normalized * (Speed / 100);
        }
        else
        {
            Vector2 dir = -(FromV - ToV);
            transform.position += new Vector3(1f * dir.x, 1f * dir.y, 1f).normalized * (Speed / 100);
        }
    }
}
