using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_attack : MonoBehaviour
{
    public GameObject Sword;

    void start()
    {
        Sword.transform.rotation = new Quaternion(0, 0, 55, 0);
    }
    IEnumerator Sus()
    { 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Sword.transform.rotation = new Quaternion(0, 0, -10, 0);
        }
    }
    private void Update()
    {

    }
}
