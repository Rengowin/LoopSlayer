using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<EnemySpawnData> enemys = new List<EnemySpawnData>();
    List<EnemySpawnData> possibleSpawns = new List<EnemySpawnData>();

    [SerializeField] GameObject enemyContainer;

    float timer = 0f;

    [SerializeField] float baseSpawnInterval = 5.0f;
    [SerializeField] float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
    }

    void Update()
    {
        if (!GameController.Instance.spawnActiv)
            return;

        timer += Time.deltaTime;

        if (timer > currentSpawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    // ============= BUFF SUPPORT =============

    public void ApplySpawnIntervalReduction(float totalReduction)
    {
        currentSpawnInterval = Mathf.Max(0.1f, baseSpawnInterval - totalReduction);
    }

    public void ApplySpawnChanceChanges(
        float reduceTier0,
        float addTier1,
        float addTier2,
        float addTier3)
    {
        foreach (var e in enemys)
        {
            if (e.Tier() == 0) e.ModifySpawnChance(-reduceTier0);
            if (e.Tier() == 1) e.ModifySpawnChance(addTier1);
            if (e.Tier() == 2) e.ModifySpawnChance(addTier2);
            if (e.Tier() == 3) e.ModifySpawnChance(addTier3);
        }
    }

    public void ApplyEnemyScaleReduction(float totalReduction)
    {
        foreach (var e in enemys)
            e.ModifyScale(totalReduction);
    }

    public float GetCurrentSpawnInterval() => currentSpawnInterval;

    // ============= EXISTIERENDE FUNKTIONEN (unverändert) =============
    private void SpawnEnemy()
    {
        GameController gc = GameController.Instance;

        int anzLoops = gc.PathManager.StartPath.TimesLooped;
        lookForPossibleSpawns();

        foreach (Path path in gc.PathManager.Paths)
        {
            EnemySpawnData data = ChooseWeigtedEnemy();

            if (data == null || data.EnemyPrefab1() == null)
                continue;

            if (!path.canSpawn())
                continue;

            GameObject obj = Instantiate(
                data.EnemyPrefab1(),
                path.GetSpawnPoint(),
                Quaternion.identity
            );

            if (enemyContainer != null)
                obj.transform.SetParent(enemyContainer.transform);

            Enemy enemy = obj.GetComponent<Enemy>();
            enemy.Init(data, anzLoops);

            path.AddEnemyToPath(enemy);
        }
    }

    private void lookForPossibleSpawns()
    {
        possibleSpawns.Clear();
        foreach (var e in enemys)
            if (e.Unlocked()) possibleSpawns.Add(e);
    }

    private EnemySpawnData ChooseWeigtedEnemy()
    {
        if (possibleSpawns.Count == 0)
            return null;

        float total = 0;
        foreach (var e in possibleSpawns) total += e.SpawnChance;

        if (total <= 0)
            return possibleSpawns[Random.Range(0, possibleSpawns.Count)];

        float r = Random.Range(0f, total);
        float c = 0;

        foreach (var e in possibleSpawns)
        {
            c += e.SpawnChance;
            if (r <= c)
                return e;
        }

        return possibleSpawns[possibleSpawns.Count - 1];
    }
}
