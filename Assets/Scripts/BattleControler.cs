using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BattelControler : MonoBehaviour
{
    public static BattelControler Instance { get; private set; }

    Player player;
    BattelManger battelManger;
    List<Enemy> enemys = new List<Enemy>();

    [SerializeField] private Spawn2DManager spawn2DManager;

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
        GameController.Instance.spawnActiv = false;
        battelManger.BattelActive = true;


        SceneToggleManager.Instance.LoadFightScene();
    }

    public void spawnEnemysAfterSecenLoad()
    {
        spawn2DManager = Spawn2DManager.Instance;
        spawn2DManager.SpawnEnemy(enemys);
    }

    public void EndBattle()
    {
        player.Speed = tempMovementSpeed;
        GameController.Instance.spawnActiv = true;


        SceneToggleManager.Instance.UnloadFightScene();
    }

    public void AddEnemy(List<Enemy> newEnemys)
    {
        foreach (Enemy enemy in newEnemys)
        {
            enemys.Add(enemy);
        }
    }

    public void RemoveEnemy(Enemy enemy) { 
        enemys.Remove(enemy);
        if(enemys.Count == 0)
        {
            EndBattle();
        }
    }
}
