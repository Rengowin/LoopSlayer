using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    List<EnemySpawnData> enemys = new List<EnemySpawnData>();

    List<EnemySpawnData> possibleSpawns = new List<EnemySpawnData>();

    [SerializeField]
    GameObject enemyContainer;

    int anzDerLoops;

    private float timer = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.spawnActiv)
        {
            timer += Time.deltaTime;
            if (timer > GameController.Instance.PathManager.SpawnInterval)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        anzDerLoops = GameController.Instance.PathManager.StartPath.TimesLooped;

        // Liste der möglichen Gegner aktualisieren
        lookForPossibleSpawns();

        foreach (Path possiblePaths in GameController.Instance.PathManager.Paths)
        {
            EnemySpawnData chosenEnemy = ChooseWeigtedEnemy();
            if (chosenEnemy == null || chosenEnemy.EnemyPrefab1() == null)
            {
                Debug.Log("No Enemy spawned");
                return;
            }

            if (possiblePaths.canSpawn())
            {
                // Gegner-Objekt erzeugen
                GameObject enemyObject = Instantiate(chosenEnemy.EnemyPrefab1(), possiblePaths.GetSpawnPoint(), Quaternion.identity);

                // Gegner-Objekt in den enemyContainer verschieben
                if (enemyContainer != null)
                {
                    enemyObject.transform.SetParent(enemyContainer.transform);
                }
                else
                {
                    Debug.LogWarning("EnemyContainer ist nicht zugewiesen. Gegner wird direkt in der Szene platziert.");
                }

                // Gegner initialisieren
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.Init(chosenEnemy, anzDerLoops);

                // Gegner dem Pfad hinzufügen
                possiblePaths.AddEnemyToPath(enemy);
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
