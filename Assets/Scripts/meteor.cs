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

    private (int, int) position;

    private float nextActionTime = 0.0f;
    public float period = 3.0f;
    public (int, int) pos()
    {
        x = Random.Range(-8, 8);
        y = Random.Range(-5, 5);
        return (x, y);
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            position = pos();
            x = position.Item1;
            y = position.Item2;
            Instantiate(shadow, new Vector2(x, y), Quaternion.identity);
        }
    }
}
