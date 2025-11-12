using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BattelControler : MonoBehaviour
{
    public static BattelControler Instance { get; private set; }

    Player player;
    BattelManger battelManger;
    List<Enemy> enemys = new List<Enemy>();
    Spawn2DManager spawn2DManager;

    public Player Player
    {
        get => player;
    }
    public BattelManger BattelManger
    {
        get => battelManger;
    }

    public List<Enemy> Enemys
    {
        get => enemys;
        set => enemys = value;
    }

    public Spawn2DManager Spawn2DManager
    {
        get => spawn2DManager;
    }



    float tempMovementSpeed, tempSpawnInterval;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<Player>();
        battelManger = FindObjectOfType<BattelManger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {
        tempMovementSpeed = player.Speed;
        player.Speed = 0;
        SceneToggleManager.Instance.LoadFightScene();
        GameController.Instance.spawnActiv = false;
        battelManger.Enemies = enemys;
        battelManger.Player = player;

        battelManger.BattelActive = true;
        


    }

    public void spawnEnemysAfterSecenLoad()
    {
        spawn2DManager = FindObjectOfType<Spawn2DManager>();
        int enemyCount = (enemys == null) ? 0 : enemys.Count;
        Debug.Log($"spawnEnemysAfterSecenLoad: Spawn2DManager found={(spawn2DManager != null)}, enemysCount={enemyCount}");

        if (spawn2DManager == null)
        {
            Debug.LogError("spawnEnemysAfterSecenLoad: Kein Spawn2DManager gefunden. Spawn abgebrochen.");
            return;
        }

        if (enemys == null || enemys.Count == 0)
        {
            Debug.LogWarning("spawnEnemysAfterSecenLoad: Keine Gegner in der Liste (enemys). Nichts zum Spawnen.");
            return;
        }

        spawn2DManager.SpawnEnemy(enemys);
    }

    public void EndBattle()
    {
        player.Speed = tempMovementSpeed;
        GameController.Instance.spawnActiv = true;

        enemys?.Clear();

        SceneToggleManager.Instance.UnloadFightScene();
    }

    public void AddEnemy(List<Enemy> newEnemys)
    {
        foreach (Enemy enemy in newEnemys)
        {
            enemys.Add(enemy);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        // Entferne den Gegner aus der Battle-Liste
        enemys.Remove(enemy);

        // Informiere den Spawn2DManager, dass der Gegner entfernt wurde
        if (spawn2DManager != null)
        {
            spawn2DManager.EnemieDied(enemy.gameObject); // Übergibt das GameObject der Enemy-Instanz
        }
        else
        {
            Debug.LogWarning("Spawn2DManager ist null. Enemy konnte nicht aus der Visual-Liste entfernt werden.");
        }

        // Beende den Kampf, wenn keine Gegner mehr übrig sind
        if (enemys.Count == 0)
        {
            EndBattle();
        }
    }
}
