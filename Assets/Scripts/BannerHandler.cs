using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets;
public class BannerHandler : MonoBehaviour
{
    

    private void Start() {
        UpdateBanner();
    }
    /// <summary>
    /// Updates the visual banner, to display who is winning
    /// </summary>
    private void UpdateBanner() {
        // Get Total and team's score
        int playerScore = GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Player).Sum(x=>x.UnitsInside);
        int enemyScore = GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Enemy).Sum(x=>x.UnitsInside);
        int totalScore = playerScore + enemyScore;
        print(playerScore);
    }
}
