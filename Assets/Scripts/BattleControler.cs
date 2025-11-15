using UnityEngine;
using System.Collections.Generic;

public class BattelControler : MonoBehaviour
{
    public static BattelControler Instance { get; private set; }

    Player player;
    BattelManger battelManger;
    List<Enemy> enemys = new List<Enemy>();
    Spawn2DManager spawn2DManager;

    float tempMovementSpeed;
    float tempHealSpeed;

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

    // ------------------------------------------------------
    // KAMPF STARTEN
    // ------------------------------------------------------
    public void StartBattle()
    {
        // Player einfrieren
        tempMovementSpeed = player.Speed;
        tempHealSpeed = player.HealSpeed;

        player.HealSpeed = 0;
        player.Speed = 0;

        // Szene wechseln
        SceneToggleManager.Instance.LoadFightScene();
        GameController.Instance.spawnActiv = false;

        // Gegnerliste an BattelManager übergeben
        battelManger.Enemies = enemys;
        battelManger.Player = player;

        battelManger.BattelActive = true;
    }

    // ------------------------------------------------------
    // NACH SZENE-LADEN → Gegner + Player UI spawnen
    // ------------------------------------------------------
    public void spawnEnemysAfterSecenLoad()
    {
        spawn2DManager = FindObjectOfType<Spawn2DManager>();

        int enemyCount = enemys == null ? 0 : enemys.Count;
        Debug.Log($"spawnEnemysAfterSecenLoad: Spawn2DManager found={(spawn2DManager != null)}, enemysCount={enemyCount}");

        if (spawn2DManager == null)
        {
            Debug.LogError("spawnEnemysAfterSecenLoad: Kein Spawn2DManager gefunden. Spawn abgebrochen.");
            return;
        }

        if (enemys == null || enemys.Count == 0)
        {
            Debug.LogWarning("spawnEnemysAfterSecenLoad: Keine Gegner vorhanden.");
            return;
        }

        // Gegner + Enemy UI erstellen
        spawn2DManager.SpawnEnemy(enemys);

        // Player UI erstellen
        BattleUIController.Instance.CreatePlayerUI(player);
    }

    // ------------------------------------------------------
    // KAMPF BEENDEN
    // ------------------------------------------------------
    public void EndBattle()
    {
        // Player Movement + Heal wieder aktivieren
        player.Speed = tempMovementSpeed;
        player.HealSpeed = tempHealSpeed;

        GameController.Instance.spawnActiv = true;

        // UI entfernen
        if (BattleUIController.Instance != null)
            BattleUIController.Instance.RemovePlayerUI();

        enemys?.Clear();

        SceneToggleManager.Instance.UnloadFightScene();
    }

    // ------------------------------------------------------
    // Gegner hinzufügen
    // ------------------------------------------------------
    public void AddEnemy(List<Enemy> newEnemys)
    {
        foreach (Enemy enemy in newEnemys)
            enemys.Add(enemy);
    }

    // ------------------------------------------------------
    // Gegner entfernen (durch Tod)
    // ------------------------------------------------------
    public void RemoveEnemy(Enemy enemy)
    {
        enemys.Remove(enemy);

        if (spawn2DManager != null)
        {
            // VISUAL entfernen über EnemyVisualPair
            EnemyVisualPair pair = spawn2DManager.GetPairForEnemy(enemy);

            if (pair != null)
                spawn2DManager.EnemieDied(pair.visual);
            else
                Debug.LogWarning("RemoveEnemy(): Kein Visual-Pair gefunden.");
        }

        // wenn keine Gegner mehr → Kampf beenden
        if (enemys.Count == 0)
            EndBattle();
    }
}
