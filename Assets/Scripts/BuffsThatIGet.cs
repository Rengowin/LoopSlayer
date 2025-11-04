using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuffsThatIGet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string HPBuff = "HP Buff", DMGBuff = "DMG Buff", AKTSpeedBuff = "AKT Speed Buff";

    List<float> HPBuffAmountTile = new List<float>();
    List<float> DMGBuffAmountTile = new List<float>();
    List<float> AKTSpeedBuffAmountTile = new List<float>();

    float TotalHPBuff = 0, TotalDMGBuff, TotalAKTSpeedBuff;



    static float elapsedTime = 0;


    //GlobalTileBuff ist zurzeit über boxcolider regelt der viel zu groß ist
    //float GlobalHPBuff, GlobalDMGBuff, GlobalAKTSpeedBuff;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime>=4.0f)
        {

            Debug.Log("Total HP Buff: " + TotalHPBuff);
            elapsedTime = 0;
        }

    }

    private void LateUpdate()
    {
        
    }

    public void AddBuff(string buffName, float buffAmount)
    {
        if(buffName == HPBuff)
        {
            Debug.Log("Füge HP Buff hinzu: " + buffAmount);
            HPBuffAmountTile.Add(buffAmount);
            TotalHPBuff = 0;
            foreach(float buff in HPBuffAmountTile)
            {
                TotalHPBuff += buff;
            }

        }
        else if(buffName == DMGBuff)
        {
            //Füge DMG Buff hinzu
        }
        else if(buffName == AKTSpeedBuff)
        {
            //Füge AKT Speed Buff hinzu
        }
    }

    public void RemoveBuff(string buffName, float buffAmount)
    {
        if (buffName == HPBuff)
        {
            Debug.Log("Entferne HP Buff: " + buffAmount);
            HPBuffAmountTile.Remove(buffAmount);
            TotalHPBuff = 0;
            foreach (float buff in HPBuffAmountTile)
            {
                TotalHPBuff += buff;
            }
        }
        else if (buffName == DMGBuff)
        {
            //Entferne DMG Buff
        }
        else if (buffName == AKTSpeedBuff)
        {
            //Entferne AKT Speed Buff
        }
    }
}
