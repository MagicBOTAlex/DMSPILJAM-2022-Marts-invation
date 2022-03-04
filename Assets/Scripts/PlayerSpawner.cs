using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPref;
    private float killDelay = 5f;

    /// <summary>
    /// Spawns the player in the worlds origin. Used by the spawn player abillity
    /// </summary>
    public void SpawnPlayer() {
        Instantiate(playerPref, Vector3.zero, Quaternion.identity);
        StartCoroutine(KillPlayer(killDelay));
    }

    private IEnumerator KillPlayer(float dl) {
        yield return new WaitForSecondsRealtime(dl);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
