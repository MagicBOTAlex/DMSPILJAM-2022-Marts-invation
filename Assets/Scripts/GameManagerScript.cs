using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;


    public List<GameObject> Bases_ = new List<GameObject>();
    public static List<GameObject> Bases { get { return instance.Bases_; } set { instance.Bases_ = value; } }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
