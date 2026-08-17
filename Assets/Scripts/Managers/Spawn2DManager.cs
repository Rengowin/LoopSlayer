using System.Collections.Generic;
using UnityEngine;

public class Spawn2DManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();

    private List<Vector3> spawnPoints = new List<Vector3>();
    private List<EnemyVisualPair> activeEnemies = new List<EnemyVisualPair>();

    public bool IsInitialized { get; private set; } = false;

    void Start()
    {
        
        spawnPoints.Add(new Vector3(4, 3, 0));
        spawnPoints.Add(new Vector3(4, -1, 0));
        spawnPoints.Add(new Vector3(2, 4.5f, 0));
        spawnPoints.Add(new Vector3(2, -2.5f, 0));
        spawnPoints.Add(new Vector3(4, 1, 0));

        IsInitialized = true;
    }

    public void SpawnEnemy(List<Enemy> enemies)
    {
        BattleUIController.Instance.ResetEnemyUIIndex();

        for (int i = 0; i < enemies.Count && i < spawnPoints.Count; i++)
        {
            Enemy enemy = enemies[i];
            GameObject prefab = GetEnemyPrefab(enemy.Name);
            GameObject visual = Instantiate(prefab, spawnPoints[i], Quaternion.identity);

            EnemyVisualPair pair = new EnemyVisualPair(enemy, visual);
            activeEnemies.Add(pair);

            GameObject uiObj = BattleUIController.Instance.CreateEnemyUIAndReturn(enemy);
            pair.uiObject = uiObj;
        }
    }


    private GameObject GetEnemyPrefab(string name)
    {
        switch (name)
        {
            case "Slime":
                return enemyPrefabs[0];
            case "Bat":
                return enemyPrefabs[1];
            case "Rock":
                return enemyPrefabs[2];
            default:
                return null;
        }
    }

    public void EnemieDied(GameObject enemyVisual)
    {
        EnemyVisualPair pair = activeEnemies.Find(p => p.visual == enemyVisual);

        if (pair != null)
        {
            pair.DestroyVisual();

            if (pair.uiObject != null)
            {
                BattleUIController.Instance.RemoveEnemyUI(pair.uiObject);
            }

            activeEnemies.Remove(pair);
        }
        else
        {
            Debug.LogWarning("EnemyVisualPair NOT found for: " + enemyVisual.name);
        }
    }

    public EnemyVisualPair GetPairForEnemy(Enemy e)
    {
        return activeEnemies.Find(p => p.enemy == e);
    }


}
