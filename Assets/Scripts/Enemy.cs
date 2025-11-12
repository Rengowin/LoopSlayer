using System;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawnData data;

    string name;

    float hp;
    float dmg;
    float aktSpeed;
    float dropChance;

    int scoreOneKill;
    int dropAmount;

    float currentActionTimer;

    public float HP{
        get => hp;
        set
        {
            hp = value;
            if(hp <= 0)
            {
                hp = 0;
                Die();
            }
        }
    }

    public string Name
    {
        get => name; set => name = value;
    }
    public float DMG
    {
        get => dmg; set => dmg = value;
    }
    public float AktSpeed
    {
        get => aktSpeed; set => aktSpeed = value;
    }
    public float DropChance
    {
        get => dropChance; set => dropChance = value;
    }

    public int ScoreOneKill
    {
        get => scoreOneKill; set => scoreOneKill = value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void Init(EnemySpawnData spawnData, int anzLoops = 0)
    {
        data = spawnData;
        name = data.EnemyName();
        hp = (float)(data.BaseHealth() * Math.Pow(data.ScalePerLoop(), anzLoops));
        dmg = (float)(data.BaseDamage() * Math.Pow(data.ScalePerLoop(), anzLoops));
        aktSpeed = data.BaseAktSpeed();
        scoreOneKill = data.ScoreOneKill() + (int)(data.ScoreOneKill() * anzLoops); //TODO: vlt zu starkes score scaling wenn fertig ist anschauen :D
        dropChance = data.BaseDropChance();
        currentActionTimer = aktSpeed;
        dropAmount = data.UpgradePointsOnKill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateActionTimer(float deltaTime)
    {
        currentActionTimer -= deltaTime;
    }

    public bool IsActionReady()
    {
        Debug.Log("Es kann angreifen");
        return currentActionTimer <= 0;
    }
    public void ResetActionTimer()
    {
        currentActionTimer = aktSpeed;
    }

    void Die()
    {
        if(UnityEngine.Random.value < DropChance)
        {
            UpgradeManager upgradeManager = FindObjectOfType<UpgradeManager>();
            if (upgradeManager != null)
            {
                upgradeManager.getUpgratePoint(dropAmount);
            }
        }
        Spawn2DManager.Instance.EnemieDied(gameObject);
        BattelControler.Instance.Enemys.Remove(this);

        Destroy(gameObject);
    }
}
