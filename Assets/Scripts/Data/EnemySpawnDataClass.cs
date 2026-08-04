using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] string enemyName;
    [SerializeField] int tier;
    [SerializeField, Range(0f, 3f)] float spawnChance;
    [SerializeField] bool unlocked = true;

    [Header("BaseStats")]
    [SerializeField] int baseHealth;
    [SerializeField] int baseDamage;
    [SerializeField] float baseAktSpeed;

    [Header("Scaling")]
    [SerializeField] float scalePerLoop;

    [Header("Rewards")]
    [SerializeField] float baseDropChance;
    [SerializeField] int upgradePointsOnKill;
    [SerializeField] int scoreOneKill;

    // === Getter/Setter ===
    public GameObject EnemyPrefab1() => EnemyPrefab;
    public string EnemyName() => enemyName;
    public int Tier() => tier;

    public float SpawnChance
    {
        get => spawnChance;
        set => spawnChance = Mathf.Clamp(value, 0f, 3f);
    }

    public float ScalePerLoop
    {
        get => scalePerLoop;
        set => scalePerLoop = Mathf.Max(0.01f, value);
    }

    // === BUFF METHODS ===

    // SpawnChance ändern (Add/Remove)
    public void ModifySpawnChance(float delta)
    {
        spawnChance = Mathf.Clamp(spawnChance + delta, 0f, 3f);
    }

    // Scale reduzieren (z. B. kleinere Gegner)
    public void ModifyScale(float delta)
    {
        scalePerLoop = Mathf.Max(0.1f, scalePerLoop - delta);
    }

    // Getter
    public bool Unlocked() => unlocked;
    public int BaseHealth() => baseHealth;
    public int BaseDamage() => baseDamage;
    public float BaseAktSpeed() => baseAktSpeed;

    public float BaseDropChance() => baseDropChance;
    public int UpgradePointsOnKill() => upgradePointsOnKill;
    public int ScoreOneKill() => scoreOneKill;
}
