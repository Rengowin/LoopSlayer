using NUnit.Framework.Internal.Commands;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    int maxEnemies;
    private List<Enemy> enemiesOnPath = new List<Enemy>();
    private BattelManger battelManger;
    private Vector3 spawnPoint;

    
    // Gegner zu diesem Weg hinzufügen
    public void AddEnemyToPath(Enemy enemy)
    {
        if(enemiesOnPath.Count <= maxEnemies)
        {
            enemiesOnPath.Add(enemy);
        }
        else
        {
            return;
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
            battelManger.Enemies = enemiesOnPath;
            battelManger.BattelActive = true;
            Debug.Log($"Es wurden {enemiesOnPath.Count} Gegner an den BattleManager übergeben.");

            enemiesOnPath.Clear();
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return transform.position+Vector3.up;
    }
}
