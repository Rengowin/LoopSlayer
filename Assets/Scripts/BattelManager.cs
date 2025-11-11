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

    public List<Enemy> Enemies { get => enemies; set => enemies = value; }
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
            if(player.Speed != 0)
            {
                tempMovementSpeed = player.Speed;
                player.Speed = 0;
            }
            player.UpdateActionTimer();
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateActionTimer();
            }
            if (player.IsActionReady())
            {
                PlayerAction();
                player.ResetActionTimer();
            }
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsActionReady())
                {
                    EnemyAction(enemy);
                    enemy.ResetActionTimer();
                }
            }
            if(enemies.Count == 0)
            {
                battelActive = false;
                player.Speed = tempMovementSpeed;
            }
        }
    }

    public void EnemyAction(Enemy enemy)
    {
        player.HP -= enemy.DMG;
    }

    public void PlayerAction()
    {
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
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
