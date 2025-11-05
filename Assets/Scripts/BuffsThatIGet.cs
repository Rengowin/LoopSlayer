using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuffsThatIGet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string HPBuff = "HP Buff", DMGBuff = "DMG Buff", AKTSpeedBuff = "AKT Speed Buff";

    List<float> HPBuffAddition = new List<float>();
    List<float> DMGBuffAddition = new List<float>();
    List<float> ATKSpeeedAddition = new List<float>();

    List<float> HPBuffMultiy = new List<float>();
    List<float> DMGBuffMultiy = new List<float>();
    List<float> ATKSpeeedMultiy = new List<float>();

    float TotalHPBuff, TotalDMGBuff, TotalAKTSpeedBuff;

    [SerializeField]
    float BaseHP, BaseDMG, BaseAKTSpeed;


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
            Debug.Log("Total DMG Buff: " + TotalDMGBuff);
            Debug.Log("Total AKT Speed Buff: " + TotalAKTSpeedBuff);
            elapsedTime = 0;
        }

    }

    public void AddBuff(string buffName, float buffAmount, bool multi)
    {
        switch (buffName)
        {
            case "HP Buff":
                if(multi)
                {
                    Debug.Log("Füge HP Buff Multiy hinzu: " + buffAmount);
                    HPBuffMultiy.Add(buffAmount);
                }
                else
                {
                    Debug.Log("Füge HP Buff hinzu: " + buffAmount);
                    HPBuffAddition.Add(buffAmount);
                }
                CalcBuff(HPBuffAddition, HPBuffMultiy, ref TotalHPBuff, BaseHP);
                break;

            case "DMG Buff":
                if(multi)
                {
                    Debug.Log("Füge DMG Buff Multiy hinzu: " + buffAmount);
                    DMGBuffMultiy.Add(buffAmount);
                }
                else
                {
                    Debug.Log("Füge DMG Buff hinzu: " + buffAmount);
                    DMGBuffAddition.Add(buffAmount);
                }
                CalcBuff(DMGBuffAddition, DMGBuffMultiy, ref TotalDMGBuff, BaseDMG);
                break;

            case "AKT Speed Buff":
                if(multi)
                {
                    Debug.Log("Füge AKT Speed Buff Multiy hinzu: " + buffAmount);
                    ATKSpeeedMultiy.Add(buffAmount);
                }
                else
                {
                    Debug.Log("Füge AKT Speed Buff hinzu: " + buffAmount);
                    ATKSpeeedAddition.Add(buffAmount);
                }
                CalcBuff(ATKSpeeedAddition, ATKSpeeedMultiy, ref TotalAKTSpeedBuff, BaseAKTSpeed, false);
                break;

            default:
                Debug.LogWarning($"Unbekannter Buff-Typ: {buffName}");
                break;
        }
    }

    public void RemoveBuff(string buffName, float buffAmount, bool multi)
    {
        switch (buffName)
        {
            case "HP Buff":
                if (multi)
                {
                    Debug.Log("Füge HP Buff Multiy hinzu: " + buffAmount);
                    HPBuffMultiy.Remove(buffAmount);
                }
                else
                {
                    Debug.Log("Füge HP Buff hinzu: " + buffAmount);
                    HPBuffAddition.Remove(buffAmount);
                }
                CalcBuff(HPBuffAddition, HPBuffMultiy, ref TotalHPBuff, BaseHP);
                break;

            case "DMG Buff":
                if(multi)
                {
                    Debug.Log("Entferne DMG Buff Multiy: " + buffAmount);
                    DMGBuffMultiy.Remove(buffAmount);
                }
                else
                {
                    Debug.Log("Entferne DMG Buff: " + buffAmount);
                    DMGBuffAddition.Remove(buffAmount);
                }
                CalcBuff(DMGBuffAddition, DMGBuffMultiy, ref TotalDMGBuff, BaseDMG);
                break;

            case "AKT Speed Buff":
                if(multi)
                {
                    Debug.Log("Entferne AKT Speed Buff Multiy: " + buffAmount);
                    ATKSpeeedMultiy.Remove(buffAmount);
                }
                else
                {
                    Debug.Log("Entferne AKT Speed Buff: " + buffAmount);
                    ATKSpeeedAddition.Remove(buffAmount);
                }
                break;

            default:
                Debug.LogWarning($"Unbekannter Buff-Typ: {buffName}");
                break;
        }
    }


    private void CalcBuff(List<float> addtionons, List<float> multipliers, ref float total, float baseStat, bool grows = true)
    {
        total = baseStat;
        if (grows)
        {
            foreach (float addition in addtionons)
            {
                total += addition;
            }
            foreach (float multiy in multipliers)
            {
                total *= multiy;
            }
        }
        else
        {
            foreach (float addition in addtionons)
            {
                total -= addition;
            }
            foreach (float multiy in multipliers)
            {
                total /= multiy;
            }
        }
    }
}
