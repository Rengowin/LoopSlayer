using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField]
    List<Path> paths = new List<Path>();

    [SerializeField]
    float spawnInterval;

    StartPath startPath;
    int anzDerLoops;

    public int AnzDerLoops { get => anzDerLoops; set => anzDerLoops = value; }
    public List<Path> Paths { get => paths; }

    public StartPath StartPath { get => startPath; }

    public float SpawnInterval { get => spawnInterval; set => spawnInterval = value; }


    void Awake()
    {
        // Alle Wege in der Szene finden und zur Liste hinzufügen
        paths.AddRange(FindObjectsOfType<Path>());
        Debug.Log($"Es wurden {paths.Count} Wege automatisch registriert.");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPath = FindObjectOfType<StartPath>();
    }

    // Update is called once per frame
    void Update()
    {
        anzDerLoops = startPath.TimesLooped;
    }
}
