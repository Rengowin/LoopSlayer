using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathManger : MonoBehaviour
{
    [SerializeField]
    List<Path> paths = new List<Path>();

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    float spawnChance = 0.3f;

    public List<Path> Paths { get => paths; }

    public float SpawnInterval { get => spawnInterval; }

    public float SpawnChance { get => spawnChance;
        set { spawnChance = value; }
    }

    void Awake()
    {
        // Alle Wege in der Szene finden und zur Liste hinzufügen
        paths.AddRange(FindObjectsOfType<Path>());
        Debug.Log($"Es wurden {paths.Count} Wege automatisch registriert.");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
