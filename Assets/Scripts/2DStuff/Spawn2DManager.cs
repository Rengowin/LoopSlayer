using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2DManager : MonoBehaviour
{
    public static Spawn2DManager Instance { get; private set; }

    List<Vector3> spawnCorts = new List<Vector3>();

    [SerializeField]
    List<GameObject> enemyPrefabs = new List<GameObject>();

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCorts.Add(new Vector3(4, 3, 0));
        spawnCorts.Add(new Vector3(4, -1, 0));
        spawnCorts.Add(new Vector3(2, 4.5f, 0));
        spawnCorts.Add(new Vector3(2, -2.5f, 0));
        spawnCorts.Add(new Vector3(4, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(List<Enemy> enemies)
    {
        int i = 0;
        foreach (Enemy enemy in enemies)
        {
            if (i>= spawnCorts.Count) { 
                Debug.Log("No more spawn points available! somehow to manyEnemys");
            break;
            }
            GameObject prefab = GetEnemyPrefab(enemy.Name);
            if( prefab != null)
            {
                var instance = Instantiate(prefab, spawnCorts[i], Quaternion.identity);
                activeEnemies.Add(instance);
            }
            i++;
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
                 return null;
        }
    }
    public void EnemieDied(GameObject enemy)
    {
        if(activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Destroy(enemy);
        }
    }
}
