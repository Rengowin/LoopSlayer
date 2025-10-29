using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuffsThatIGet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string HPBuff = "HP Buff", DMGBuff = "DMG Buff", AKTSpeedBuff = "AKT Speed Buff";

    List<float> HPBuffAmountTile;
    List<float> DMGBuffAmountTile;
    List<float> AKTSpeedBuffAmountTile;

    float GlobalHPBuff, GlobalDMGBuff, GlobalAKTSpeedBuff;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    public void AddBuff(string buffName, float buffAmount)
    {
        if(buffName == HPBuff)
        {
            //Füge HP Buff hinzu
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
}
