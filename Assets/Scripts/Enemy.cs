using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float baseHP;
    [SerializeField]
    float baseDMG;
    [SerializeField]
    float baseAKTSpeed;
    [SerializeField]
    float baseDropChance;

    float hp;
    float dmg;
    float aktSpeed;
    float dropChance;

    float currentActionTimer;

    public float HP{
        get => baseHP;
        set
        {
            baseHP = value;
            if(baseHP <= 0)
            {
                baseHP = 0;
                Die();
            }
        }
    }

    public float DMG
    {
        get => dmg; set => baseDMG = dmg;
    }
    public float AktSpeed
    {
        get => baseAKTSpeed; set => baseAKTSpeed = value;
    }
    public float DropChance
    {
        get => baseDropChance; set => baseDropChance = value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = baseHP;
        dmg = baseDMG;
        aktSpeed = baseAKTSpeed;
        dropChance = baseDropChance;
        currentActionTimer = aktSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateActionTimer()
    {
        currentActionTimer -= Time.deltaTime;
    }

    public bool IsActionReady()
    {
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
                upgradeManager.getUpgratePoint();
            }
        }
        
        BattelManger.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
