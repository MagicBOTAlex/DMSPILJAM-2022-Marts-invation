using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;


    public List<TowerInfo> Bases_ = new List<TowerInfo>();
    public static List<TowerInfo> Bases { get { return instance.Bases_; } set { instance.Bases_ = value; } }

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
