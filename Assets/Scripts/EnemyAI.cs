using System.Linq;
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float FirstEventDelay = 10f;
    public float EventDelay = 5f;

    List<TowerInfo> Towers { get { return GameManagerScript.instance.Towers_; } set { GameManagerScript.instance.Towers_ = value; } }
    List<TowerInfo> EnemyTowers { get { return GameManagerScript.instance.Towers_.Where(x=>x.Type == TowerType.Enemy).ToList(); } }
    void SendUnits(TowerInfo from, TowerInfo to, int amount) => GameManagerScript.instance.SendUnits(from, to, amount);

    void Start()
    {
        StartCoroutine(StartEventing());
    }

    IEnumerator StartEventing()
    {
        yield return new WaitForSecondsRealtime(FirstEventDelay);

        while (true)
        {
            yield return new WaitForSecondsRealtime(EventDelay);
            break;
        }
    }

    void GatherAllEvent()
    {

    }
}
