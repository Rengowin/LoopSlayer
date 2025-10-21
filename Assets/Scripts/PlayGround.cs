using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    Fields[,] fields = new Fields[13,13];
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
        fields[0, 0] = Instantiate();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
