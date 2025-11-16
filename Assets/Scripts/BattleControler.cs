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
    bool aktivHeal;

    private bool fightSceneLoaded = false; // verhindert doppelte Loads

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
        if (fightSceneLoaded)
        {
            Debug.LogWarning("StartBattle wurde doppelt aufgerufen!");
            return;
        }

        // Player einfrieren
        tempMovementSpeed = player.Speed;

        //HealSpeed should be false that the player can't heal during battle
        player.Speed = 0;

        // UI auf Kampfmodus
        UIVisibilityManager.Instance.ShowFightUI();

        // Spawn in der normalen Welt stoppen
        GameController.Instance.spawnActiv = false;

        // Gegnerliste an BattleManager übergeben
        battelManger.Enemies = enemys;
        battelManger.Player = player;
        battelManger.BattelActive = true;

        // FightScene laden
        SceneToggleManager.Instance.LoadFightScene();
        fightSceneLoaded = true;
    }

    // ------------------------------------------------------
    // NACH SZENE-LADEN → Gegner + Player UI spawnen
    // ------------------------------------------------------
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

        // Gegner spawnen
        spawn2DManager.SpawnEnemy(enemys);

        // Player UI erzeugen
        BattleUIController.Instance.CreatePlayerUI(player);
    }

    // ------------------------------------------------------
    // KAMPF BEENDEN
    // ------------------------------------------------------
    public void EndBattle()
    {
        // Player zurücksetzen
        player.Speed = tempMovementSpeed;

        // Spawning wieder aktivieren
        GameController.Instance.spawnActiv = true;

        // UI auf normalen Modus
        UIVisibilityManager.Instance.ShowNormalUI();

        // UI entfernen
        if (BattleUIController.Instance != null)
            BattleUIController.Instance.RemovePlayerUI();

        enemys?.Clear();

        // FightScene entladen
        if (fightSceneLoaded)
        {
            SceneToggleManager.Instance.UnloadFightScene();
            fightSceneLoaded = false;
        }
    }

    // ------------------------------------------------------
    // Gegner hinzufügen
    // ------------------------------------------------------
    public void AddEnemy(List<Enemy> newEnemys)
    {
        enemys.AddRange(newEnemys);
    }

    // ------------------------------------------------------
    // Gegner entfernen (durch Tod)
    // ------------------------------------------------------
    public void RemoveEnemy(Enemy enemy)
    {
        enemys.Remove(enemy);

        if (spawn2DManager != null)
        {
            EnemyVisualPair pair = spawn2DManager.GetPairForEnemy(enemy);

            if (pair != null)
                spawn2DManager.EnemieDied(pair.visual);
        }

        if (enemys.Count == 0)
            EndBattle();
    }
}
