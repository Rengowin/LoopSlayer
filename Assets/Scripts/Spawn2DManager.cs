using System.Collections.Generic;
using UnityEngine;

public class Spawn2DManager : MonoBehaviour
{
    List<Vector3> spawnCorts = new List<Vector3>();

    [SerializeField]
    List<GameObject> enemyPrefabs = new List<GameObject>();

    private List<EnemyVisualPair> activeEnemy = new List<EnemyVisualPair>();

    public bool IsInitialized { get; private set; } = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCorts.Add(new Vector3(4, 3, 0));
        spawnCorts.Add(new Vector3(4, -1, 0));
        spawnCorts.Add(new Vector3(2, 4.5f, 0));
        spawnCorts.Add(new Vector3(2, -2.5f, 0));
        spawnCorts.Add(new Vector3(4, 1, 0));
        Debug.Log("Spawn2DManager: spawnCorts are set!");
        IsInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy(List<Enemy> enemies)
    {
        for (int i = 0; i < enemies.Count && i < spawnCorts.Count; i++)
        {
            GameObject prefab = GetEnemyPrefab(enemies[i].Name);
            if (prefab == null)
            {
                Debug.LogWarning($"No prefab found for enemy: {enemies[i].Name}");
                continue;
            }

            GameObject visual = Instantiate(prefab, spawnCorts[i], Quaternion.identity);
            activeEnemy.Add(new EnemyVisualPair(enemies[i], visual));

            Debug.Log($"Spawned EnemyVisualPair: Enemy={enemies[i].Name}, Visual={visual.name}");
        }
    }

    private GameObject GetEnemyPrefab(string enemyName)
    {
        switch (enemyName)
        {
            case "Slime":
                return enemyPrefabs[0];
            case "Bat":
                return enemyPrefabs[1];
            default:
                Debug.Log("No prefab found for enemy: " + enemyName);
                return null;
        }
    }
    public void EnemieDied(GameObject enemyVisual)
    {
        Debug.Log($"EnemieDied called for visual: {enemyVisual.name}");

        // Suche nach dem Pair
        EnemyVisualPair pair = activeEnemy.Find(e => e.visual == enemyVisual);

        if (pair != null)
        {
            Debug.Log($"EnemyVisualPair found for visual: {enemyVisual.name}");
            pair.DestroyVisual();
            activeEnemy.Remove(pair);
        }
        else
        {
            Debug.LogWarning($"EnemyVisualPair not found for the given visual: {enemyVisual.name}");
            Debug.Log($"ActiveEnemy count: {activeEnemy.Count}");
            foreach (var active in activeEnemy)
            {
                Debug.Log($"ActiveEnemy: Enemy={active.enemy.Name}, Visual={active.visual.name}"); 
                //debug erfindet ja das rixchtige aber wird nicht bisher richtige geöffnet
                active.DestroyVisual();
            }
        }
    }
}
