using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattelManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    List<Enemy> enemies = new List<Enemy>();

    private Player player;
    float tempMovementSpeed;
    bool battelActive = false;
    public bool BattelActive { get => battelActive; set => battelActive = value; }

void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log("Player found "+player.Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (battelActive)
        {
            battelLoop();
        }
    }

    private void battelLoop()
    {
        if (player.Speed != 0)
        {
            tempMovementSpeed = player.Speed;
            player.Speed = 0;
        }
        {
            Debug.Log("fight start");
            player.UpdateActionTimer(Time.deltaTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateActionTimer(Time.deltaTime);
            }
            if (player.IsActionReady())
            {
                Debug.Log("Es sollte angreifen mal schauen vom Spieler :D");
                PlayerAction();
                player.ResetActionTimer();
            }
            foreach (Enemy enemy in enemies)
            {
                Debug.Log("Es sollte angreifen mal schauen vom gegner :D");
                if (enemy.IsActionReady())
                {
                    EnemyAction(enemy);
                    enemy.ResetActionTimer();
                }
            }
            if (enemies.Count == 0)
            {
                battelActive = false;
                player.Speed = tempMovementSpeed;
                Debug.Log("Player HP nach dem fight ist: " + player.HP);
            }
        }
    }

    public void EnemyAction(Enemy enemy)
    {
        player.HP -= enemy.DMG;
        Debug.Log("Der Spieler hat: " + enemy.DMG + "dmg bekommen");
    }

    public void PlayerAction()
    {
        Debug.Log("Player Action: der spieler hat: " + player.Dmg + "dmg");
        int attackCount = Mathf.Min(player.ATKCount, enemies.Count);
        List<Enemy> availableEnemies = new List<Enemy>(enemies);

        for (int i = 0; i < attackCount; i++)
        {
            if (availableEnemies.Count == 0) break;

            int randomIndex = Random.Range(0, availableEnemies.Count);
            Enemy target = availableEnemies[randomIndex];
            target.HP -= player.Dmg;
            availableEnemies.RemoveAt(randomIndex);
        }

    }

    public void AddEnemy(List<Enemy> enemiesFromPath)
    {
        foreach(Enemy enemy in enemiesFromPath)
        {
            enemies.Add(enemy);
            Debug.Log("Es wurde ein gegen zur liste hinzugefügt");
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
