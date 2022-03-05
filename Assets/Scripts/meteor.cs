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
    public float period = 3.0f;

    int a = 0;
    public (int, int) posShad()
    {
        x = Random.Range(-8, 8);
        y = Random.Range(-5, 5);
        return (x, y);
    }
    public (int, int) posMet()
    {
        x = Random.Range(-15, -10);
        y = Random.Range(8, 10);
        return (x, y);
    }
    GameObject sus1;
    GameObject sus2;
    void FixedUpdate()
    {
        if (Time.time > nextActionTime)
        {
            if (a < 1)
            {
                nextActionTime += period;

                position1 = posShad();
                position2 = posMet();

                x = position1.Item1;
                y = position1.Item2;

                x2 = position2.Item1;
                y2 = position2.Item2;

                sus1 = Instantiate(shadow, new Vector2(x, y), Quaternion.identity);
                sus2 = Instantiate(meteorite, new Vector2(x2, y2), Quaternion.identity);
                a += 1;
            }
            else if (a > 0)
            {
                //Destroy(sus);
                a -= 1;
            }
        }
    }
}
