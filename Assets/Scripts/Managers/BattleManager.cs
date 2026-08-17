using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattelManger : MonoBehaviour
{

    List<Enemy> enemies = new List<Enemy>();

    Player player;
    bool battelActive = false;
    public bool BattelActive { get => battelActive; set => battelActive = value; }
    public List<Enemy> Enemies { get => enemies; set => enemies = value; }
    public Player Player { get => player; set => player = value; }

    void Update()
    {
        if(battelActive)
        {
            battelLoop();
        }
    }

    private void battelLoop()
    {
        {
            player.UpdateActionTimer(Time.deltaTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateActionTimer(Time.deltaTime);
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
            if (enemies.Count == 0)
            {
                battelActive = false;
                BattelControler.Instance.EndBattle();
            }
        }
    }

    public void EnemyAction(Enemy enemy)
    {
        player.currentHP -= enemy.DMG;
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
}
