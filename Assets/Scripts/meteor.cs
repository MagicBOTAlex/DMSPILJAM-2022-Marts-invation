using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteorite;
    public GameObject shadow;

    int x;
    int y;
    int x2;
    int y2;

    private (int, int) position1;
    private (int, int) position2;

    private float nextActionTime = 0.0f;
    public float period = 2.0f;


    public (int, int) posShad()
    {
        x = Random.Range(-6, 8);
        y = Random.Range(-3, 5);
        return (x, y);
    }
    public (int, int) posMet()
    {
        x = Random.Range(-15, -10);
        y = Random.Range(8, 10);
        return (x, y);
    }
    GameObject sus1; //Meteor
    GameObject sus2; //Shadow
    void FixedUpdate()
    {
        if (Time.time > nextActionTime)
        {

            nextActionTime += period;

            position1 = posShad();
            position2 = posMet();

            x = position1.Item1;
            y = position1.Item2;

            x2 = position2.Item1;
            y2 = position2.Item2;

            //sus1 = Instantiate(meteorite, new Vector2(x2, y2), Quaternion.identity);
            //sus2 = Instantiate(shadow, new Vector2(x, y), Quaternion.identity);
            Instantiate(meteorite, new Vector2(x2, y2), Quaternion.identity);
            Instantiate(shadow, new Vector2(x, y), Quaternion.identity);

        }
    }
}
