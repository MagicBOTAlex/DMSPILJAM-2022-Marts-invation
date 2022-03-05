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
    List<TowerInfo> PlayerTowers { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Player).ToList(); } }
    List<TowerInfo> NeutralTowers { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Neutral).ToList(); } }
    List<TowerInfo> EnemyTowersRandom { get { return GameManagerScript.instance.Towers_.Where(x=>x.Type == TowerType.Enemy).ToList(); } }

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
            GatherAll();
            yield return new WaitForSecondsRealtime(EventDelay);
        }
    }

    void GatherAll()
    {
        int gatherIndex = Random.Range(0, EnemyTowersRandom.Count);
        for (int i = 0; i < EnemyTowersRandom.Count; i++)
        {
            if (i == gatherIndex) continue;

            SendUnits(EnemyTowersRandom[i], EnemyTowersRandom[gatherIndex], EnemyTowersRandom[i].UnitsInside);
        }

        var attackHere = (Random.Range(0, 1) == 0) ? PlayerTowers[Random.Range(0, PlayerTowers.Count)] : NeutralTowers[Random.Range(0, NeutralTowers.Count)];
        
        print($"Enemy attacking tower: {attackHere.Object.name}");

        StartCoroutine(WaitBeforeSend(EnemyTowersRandom[gatherIndex], attackHere, attackHere.UnitsInside));
    }

    IEnumerator WaitBeforeSend(TowerInfo from, TowerInfo to, int amount)
    {
        yield return new WaitForSecondsRealtime(10);

    }
}
