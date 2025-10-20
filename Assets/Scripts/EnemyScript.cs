using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float baseHp, baseDmg, baseAktSpeed;

    private int hp, dmg;
    private float aktSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VuffsBaseOnLoop(float scaleBy, int howOffen)
    {
        //HP
        hp = (int)(baseHp * Mathf.Round(Mathf.Pow(baseHp, scaleBy)));  
        //DMG
        dmg = (int)(baseDmg * Mathf.Round(Mathf.Pow(baseDmg, scaleBy)));
    }

    public void BuffsBasedOnFiled()
    {
        //HP

        //DMG

        //AktSpeed
    }

    public void BuffsFromGlobal()
    {

    }
}
