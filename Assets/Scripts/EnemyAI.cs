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
    TowerInfo[] PlayerTowers { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Player).ToArray(); } }
    TowerInfo[] NeutralTowers { get { return GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Neutral).ToArray(); } }
    TowerInfo[] EnemyTowersRandom { get { return GameManagerScript.instance.Towers_.Where(x=>x.Type == TowerType.Enemy).ToArray(); } }

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
            GatherAll();
            yield return new WaitForSecondsRealtime(EventDelay);
        }
    }

    void GatherAll()
    {
        int gatherIndex = Random.Range(0, EnemyTowersRandom.Length);
        for (int i = 0; i < EnemyTowersRandom.Length; i++)
        {
            if (i == gatherIndex) continue;

            SendUnits(EnemyTowersRandom[i], EnemyTowersRandom[gatherIndex], EnemyTowersRandom[i].UnitsInside / 2);
        }

        StartCoroutine(WaitBeforeSend(gatherIndex));

        //StartCoroutine(WaitBeforeSend(EnemyTowersRandom[gatherIndex], attackHere, (attackHere.Type == TowerType.Neutral) ? attackHere.UnitsInside + 5 : EnemyTowersRandom[gatherIndex].UnitsInside));

        /*
        if (attackHere.Type == TowerType.Neutral)
        {
            if (NeutralTowers.Length != 0)
                attackHere = NeutralTowers[Random.Range(0, NeutralTowers.Length)];
            else
                attackHere = PlayerTowers[Random.Range(0, PlayerTowers.Length)];

            StartCoroutine(WaitBeforeSend(EnemyTowersRandom[gatherIndex], attackHere, (attackHere.Type == TowerType.Neutral) ? attackHere.UnitsInside + 5 : EnemyTowersRandom[gatherIndex].UnitsInside));
        }*/
    }

    IEnumerator WaitBeforeSend(int fromIndex)
    {
        TowerInfo attackHere = new TowerInfo();
        bool targetFound = false;
        for (int i = 0; i < PlayerTowers.Length; i++)
        {
            if (PlayerTowers[i].UnitsInside < EnemyTowersRandom[fromIndex].UnitsInside - 20)
            {
                attackHere = PlayerTowers[i];
                targetFound = true;
                break;
            }
        }

        if (!targetFound && NeutralTowers.Length != 0)
            attackHere = NeutralTowers[Random.Range(0, NeutralTowers.Length)];
        else if (NeutralTowers.Length == 0)
            attackHere = PlayerTowers[Random.Range(0, PlayerTowers.Length)];

        print($"Enemy attacking tower: {attackHere.Object.name} {attackHere.Type}");

        yield return new WaitForSecondsRealtime(10);
        if (EnemyTowersRandom[fromIndex].UnitsInside < attackHere.UnitsInside) goto Forward;

        SendUnits(EnemyTowersRandom[fromIndex], attackHere, (attackHere.Type == TowerType.Neutral) ? attackHere.UnitsInside + 5 : EnemyTowersRandom[fromIndex].UnitsInside);

    Forward:;
    }
}
