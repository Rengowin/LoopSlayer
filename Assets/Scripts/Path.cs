using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    int maxEnemies;
    private List<Enemy> enemiesOnPath = new List<Enemy>();

    
    // Gegner zu diesem Weg hinzufügen
    public void AddEnemyToPath(Enemy enemy)
    {
        if (enemiesOnPath.Count < maxEnemies)
        {
            enemiesOnPath.Add(enemy);
            Debug.Log($"Gegner {enemy.name} wurde dem Weg hinzugefügt.");
        }
        else
        {
            Debug.LogWarning("Maximale Anzahl an Gegnern auf diesem Weg erreicht!");
        }
    }

    // Gegner an den BattleManager übergeben
    private void OnTriggerEnter(Collider other)
    {
        if (enemiesOnPath.Count == 0)
        {
        }
        else
        {
            BattelManger.Instance.AddEnemy(enemiesOnPath);
            Debug.Log($"Es wurden {enemiesOnPath.Count} Gegner an den BattleManager übergeben.");

            enemiesOnPath.Clear();
        }
    }
}
