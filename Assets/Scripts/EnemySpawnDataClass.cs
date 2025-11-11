using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    string enemyName;
    [SerializeField]
    int tier;
    [SerializeField]
    [Range(0f, 1f)] float spawnChance;
    [SerializeField]
    bool unlocked = true;

    [Header("BaseStats")]
    [SerializeField]
    int baseHealth;
    [SerializeField]
    int baseDamage;
    [SerializeField]
    float baseAktSpeed;

    [Header("Scaling")]
    [SerializeField]
    int scalePerLoop;

    [Header("Rewards")]
    [SerializeField]
    float baseDropChance;
    [SerializeField]
    int upgradePointsOnKill;
    [SerializeField]
    int scoreOneKill;

    public GameObject EnemyPrefab1() => EnemyPrefab;
    public string EnemyName() => enemyName;
    public int Tier() => tier;

    public float SpawnChance() => spawnChance;
    public bool Unlocked() => unlocked;
    public int BaseHealth() => baseHealth;
    public int BaseDamage() => baseDamage;
    public float BaseAktSpeed() => baseAktSpeed;
    public int ScalePerLoop() => scalePerLoop;
    public float BaseDropChance() => baseDropChance;
    public int UpgradePointsOnKill() => upgradePointsOnKill;
    public int ScoreOneKill() => scoreOneKill;

}
