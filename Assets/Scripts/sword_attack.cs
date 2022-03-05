using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_attack : MonoBehaviour
{
    public GameObject player;


    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            player.GetComponent<Animator>().SetBool("attack", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("attack", false);
        }
    }
}
