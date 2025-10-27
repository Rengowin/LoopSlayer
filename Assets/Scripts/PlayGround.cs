using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //[SerializeField]
    //GameObject[,] fields = new GameObject[13,13];
    //why erstellt man so ein zweistufiges array?

    [SerializeField]
    List<GameObject> prefabs;

    [SerializeField]
    Vector3 howMutchUp = new Vector3(0,0,0);

    [SerializeField]
    GameObject test;

    void Start()
    {
        //create gameBorad

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
