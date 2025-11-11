using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    List<EnemySpawnData> enemys = new List<EnemySpawnData>();

    [SerializeField]
    PathManger pathManger;

    List<EnemySpawnData> possibleSpawns = new List<EnemySpawnData>();

    private StartPath startPath;

    int anzDerLoops;

    private float timer = 0f;

    void Start()
    {
        startPath = FindObjectOfType<StartPath>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > pathManger.SpawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        anzDerLoops = startPath.TimesLooped;
        {
            lookForPossibleSpawns();

            foreach (Path possiblePaths in pathManger.Paths)
            {
                EnemySpawnData chosenEnemy = ChooseWeigtedEnemy();
                if (chosenEnemy.EnemyPrefab1() == null)
                {
                    Debug.Log("No Enemy spawend");
                    return;
                }
                //TODO: Gegner werden nicht auf gehalten mit dem spawene -.- hier muss der check hin für den spawn nicht in path!!
                if (possiblePaths.canSpawn() == true)
                {
                    GameObject enemyObject = Instantiate(chosenEnemy.EnemyPrefab1(), possiblePaths.GetSpawnPoint(), Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();
                    enemy.Init(chosenEnemy, anzDerLoops);
                    possiblePaths.AddEnemyToPath(enemy);
                }
            }
        }
    }

    private void lookForPossibleSpawns()
    {
        possibleSpawns.Clear();
        foreach (EnemySpawnData enemy in enemys)
        {
            if (enemy.Unlocked() == true)
            {
                possibleSpawns.Add(enemy);
            }
        }
    }

    private EnemySpawnData ChooseWeigtedEnemy()
    {
        // Schutz gegen leere Listen
        if (possibleSpawns == null || possibleSpawns.Count == 0)
            return null;

        // Gesamtes Gewicht berechnen
        float totalWeight = 0f;
        foreach (EnemySpawnData enemy in possibleSpawns)
        {
            totalWeight += enemy.SpawnChance();
        }

        // Falls alle Gewichte 0 oder negativ sind: Fallback auf uniforme Auswahl
        if (totalWeight <= 0f)
        {
            return possibleSpawns[Random.Range(0, possibleSpawns.Count)];
        }

        // gewichtete Auswahl
        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        foreach (EnemySpawnData enemy in possibleSpawns)
        {
            cumulativeWeight += enemy.SpawnChance();
            if (randomValue <= cumulativeWeight)
                return enemy;
        }

        // Sollte wegen Rundungsfehlern nie erreicht werden — sicherer Fallback
        // Und Compile zu befiedigen ;D
        return possibleSpawns[possibleSpawns.Count - 1];
    }
}
