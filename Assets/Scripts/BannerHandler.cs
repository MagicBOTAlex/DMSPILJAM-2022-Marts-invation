using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets;
using UnityEngine.UI;
public class BannerHandler : MonoBehaviour
{
    
    private float fraqScale = 1f;
    public Image playerBar;
    public Image enemyBar;

    private void Awake() {
        fraqScale = transform.localScale.y / 100f;
        // playerBar = transform.GetChild(0).gameObject.GetComponent<Image>();
        // Debug.Log(playerBar.name);
        // playerBar = transform.GetChild(1).gameObject.GetComponent<Image>();
    }
    private void Start() {
        UpdateBanner();
        

    }
    private void FixedUpdate() {
        UpdateBanner();
    }
    /// <summary>
    /// Updates the visual banner, to display who is winning
    /// </summary>
    private void UpdateBanner() {
        // Get Total and team's score
        int playerScore = GetPlayerScore();
        int enemyScore = GetEnemyScore(); 
        int totalScore = playerScore + enemyScore;
        // print($"pScore: {playerScore}");

        // Calculate percantages of banner to fill
        float playerPer = CalculatePerc(totalScore, playerScore);
        float enemyPer = CalculatePerc(totalScore, enemyScore);
        //Debug.Log($"Plyerper: {playerPer}");
        // Set fill amount
        
        playerBar.fillAmount = playerPer;
        enemyBar.fillAmount = enemyPer;
    }

    private float CalculatePerc(int total, int denom) {
        if (denom == 0) 
            return 0f;
        return (float) denom / (float) total;
    }
    
    private int GetPlayerScore() {
        int inside = GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Player).Sum(x => x.UnitsInside);
        int outside = 0;
        for (int i = 0; i < GameManagerScript.UnitsOnMap.Count; ++i) {
            if (GameManagerScript.UnitsOnMap[i].GetComponent<UnitScript>().From.Type == TowerType.Player) {
                outside++;
            }
        }
        Debug.Log($"{outside} Units from player on map");
        return inside + outside;
    } 
    private int GetEnemyScore() {
        int inside = GameManagerScript.instance.Towers_.Where(x => x.Type == TowerType.Enemy).Sum(x => x.UnitsInside);
        int outside = 0;
        for (int i = 0; i < GameManagerScript.UnitsOnMap.Count; ++i) {
            if (GameManagerScript.UnitsOnMap[i].GetComponent<UnitScript>().From.Type == TowerType.Enemy) {
                outside++;
            }
        }
        return inside + outside;
    }
}
