using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class sword_attack : MonoBehaviour
{
    public GameObject player;

    //List<TowerInfo> Towers { get { return GameManagerScript.instance.Towers_; } set { GameManagerScript.instance.Towers_ = value; } }
    //TowerInfo[] EnemyTower { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Enemy).ToArray(); } }

    int total_units;

    int index;

    public int sword_damage;

    private float nextActionTime = 0.0f;
    public float period = 0.15f;

    bool attacking;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            player.GetComponent<Animator>().SetBool("attack", true);
            attacking = true;
        }
        else
        {
            player.GetComponent<Animator>().SetBool("attack", false);
            attacking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Towers") || player.GetComponent<Animator>().GetBool("attack") == true)
        {
            StartCoroutine(attacking_fn());
        }
    }
    IEnumerator attacking_fn()
    {
        while (Time.time > nextActionTime || attacking == true)
        {
            nextActionTime += period;

            //index = other.GetComponent<TowerIndexHolder>().TowerIndex;
            //total_units = EnemyTower[index].UnitsInside;
            //EnemyTower[index].UnitsInside -= sword_damage;
        }
        yield return null;
    }
}