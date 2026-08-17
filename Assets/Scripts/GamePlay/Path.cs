using NUnit.Framework.Internal.Commands;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    int maxEnemies;
    private List<Enemy> enemiesOnPath = new List<Enemy>();
    private BattelManger battelManger;
    private Vector3 spawnPoint;

    private void Start()
    {
        battelManger = FindObjectOfType<BattelManger>();
    }


    public void AddEnemyToPath(Enemy enemy)
    {
        if (canSpawn())
        {
            enemiesOnPath.Add(enemy);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemiesOnPath.Count == 0)
            return;

        BattelControler.Instance.Enemys = new System.Collections.Generic.List<Enemy>(enemiesOnPath);
        BattelControler.Instance.StartBattle();

        enemiesOnPath.Clear();
    }

    public bool canSpawn()
    {
        if (enemiesOnPath.Count <= maxEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return transform.position+Vector3.up;
    }
}
