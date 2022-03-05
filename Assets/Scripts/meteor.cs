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

    void Start()
    {
        position = pos();
        Debug.Log(position);
    }

    public (int, int) pos()
    {
        x = Random.Range(0, 1920);
        y = Random.Range(0, 1080);
        return (x, y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
