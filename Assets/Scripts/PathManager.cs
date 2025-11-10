using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathManger : MonoBehaviour
{
    [SerializeField]
    List<Path> paths = new List<Path>();

    [SerializeField]
    float spawnInterval;

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
