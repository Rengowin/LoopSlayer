using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattelManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    List<Enemy> enemies = new List<Enemy>();

    public static BattelManger Instance { get; private set; }

    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log("Player found"+player.Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BattelLoop()
    {
        Debug.Log("Battel Loop Running...");
        float tempPlayerSpeed = player.Speed;
        player.Speed = 0;
        while (enemies.Count > 0 && player.HP > 0)
        {
            Debug.Log("New Round Started...");

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

            foreach(Enemy enemy in enemies)
            {
                player.HP -= enemy.DMG;
            }
        }
        player.Speed = tempPlayerSpeed;

    }

    public void EnemyAction(Enemy enemy)
    {

    }

    public void PlayerAction()
    {
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
