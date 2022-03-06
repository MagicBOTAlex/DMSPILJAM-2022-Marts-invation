using System.Linq;
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_attack : MonoBehaviour
{
    public GameObject player;

    List<TowerInfo> Towers { get { return GameManagerScript.instance.Towers_; } set { GameManagerScript.instance.Towers_ = value; } }
    TowerInfo[] EnemyTower { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Enemy).ToArray(); } }

    int total_units;

    int index;

    public int sword_damage;

    private float nextActionTime = 0.0f;
    public float period = 0.15f;

    bool attacking;

    // GameObject othr;

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
        if (other.CompareTag("Towers"))
        {
            StartCoroutine(attacking_fn(other.gameObject));
        }
    }
    IEnumerator attacking_fn(GameObject othr)
    {
        while (Time.time > nextActionTime || attacking == true)
        {
            nextActionTime += period;

            index = othr.GetComponent<TowerIndexHolder>().TowerIndex;

            Debug.Log("Index:");
            Debug.Log(index);
            //EnemyTower[index].UnitsInside -= sword_damage;
            if (GameManagerScript.Towers[index].UnitsInside > 1)
            {
                GameManagerScript.Towers[index].UnitsInside -= sword_damage;
                yield return new WaitForSecondsRealtime(0.3f);
            }
            else { break; }
        }
        yield return null;
    }
}