using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattelControler : MonoBehaviour
{
    public static BattelControler Instance { get; private set; }

    Player player;
    BattelManger battelManger;
    List<Enemy> enemys = new List<Enemy>();
    Spawn2DManager spawn2DManager;

    float tempMovementSpeed;
    bool aktivHeal;

    private bool fightSceneLoaded = false;

    public Player Player => player;
    public BattelManger BattelManger => battelManger;
    public List<Enemy> Enemys { get => enemys; set => enemys = value; }
    public Spawn2DManager Spawn2DManager => spawn2DManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        battelManger = FindObjectOfType<BattelManger>();
    }

    public void StartBattle()
    {
        if (fightSceneLoaded)
        {
            Debug.LogWarning("StartBattle wurde doppelt aufgerufen!");
            return;
        }

        tempMovementSpeed = player.Speed;

        player.Speed = 0;

        UIVisibilityManager.Instance.ShowFightUI();

        GameController.Instance.spawnActiv = false;

        battelManger.Enemies = enemys;
        battelManger.Player = player;
        battelManger.BattelActive = true;

        SceneToggleManager.Instance.LoadFightScene();
        fightSceneLoaded = true;
    }

    public void spawnEnemysAfterSecenLoad()
    {
        spawn2DManager = FindObjectOfType<Spawn2DManager>();

        if (spawn2DManager == null)
        {
            Debug.LogError("Kein Spawn2DManager gefunden!");
            return;
        }

        if (enemys == null || enemys.Count == 0)
        {
            Debug.LogWarning("Keine Gegner vorhanden.");
            return;
        }

        spawn2DManager.SpawnEnemy(enemys);

        BattleUIController.Instance.CreatePlayerUI(player);
    }

    public void EndBattle()
    {
        player.Speed = 0;

        UIVisibilityManager.Instance.ShowNormalUI();

        if (BattleUIController.Instance != null)
            BattleUIController.Instance.RemovePlayerUI();

        enemys?.Clear();

        if (fightSceneLoaded)
        {
            SceneToggleManager.Instance.UnloadFightScene();
            fightSceneLoaded = false;
        }

        StartCoroutine(ResumeGameAfterDelay(1f));
    }

    private IEnumerator ResumeGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.Speed = tempMovementSpeed;
        GameController.Instance.spawnActiv = true;
    }

    public void AddEnemy(List<Enemy> newEnemys)
    {
        enemys.AddRange(newEnemys);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemys.Remove(enemy);

        if (spawn2DManager != null)
        {
            EnemyVisualPair pair = spawn2DManager.GetPairForEnemy(enemy);

            if (pair != null)
                spawn2DManager.EnemieDied(pair.visual);
        }
    }
}
