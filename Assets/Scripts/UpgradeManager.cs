using System.Collections.Generic;
using UnityEngine;


// this shoulod create all upgrade buttons and manage them/give the informations to the UpgradeController
public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    UpgradeController upgradeController;

    [SerializeField]
    List<BuffClass> buffClasses = new List<BuffClass>();

    [SerializeField]
    GameObject upgradeButtonPrefab;

    [SerializeField]
    GameObject upgradeButtonContainer;

    List<UpgradeButtonScript> upgradeButtons = new List<UpgradeButtonScript>();

    
    //additive buffs
    List<float> HPBuffAddition = new List<float>();
    List<float> DMGBuffAddition = new List<float>();
    List<float> ATKSpeeedAddition = new List<float>();


    //multiplicative buffs
    List<float> HPBuffMultiy = new List<float>();
    List<float> DMGBuffMultiy = new List<float>();
    List<float> ATKSpeeedMultiy = new List<float>();

    float totalHPBuff, totalDMGBuff, totalAKTSpeedBuff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (BuffClass buff in buffClasses)
        {
            createBuffButtons(buff);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createBuffButtons(BuffClass buffInfo)
    {
        GameObject obj = Instantiate(upgradeButtonPrefab);
        obj.transform.SetParent(upgradeButtonContainer.transform, false);

        var script = obj.GetComponent<UpgradeButtonScript>();
        script.Init(buffInfo, this, upgradeController);
    }
    public void applyBuff(BuffClass buff)
    {
        addToListX(buff.BuffName + (buff.BuffAddtive ? " Addition" : " Multiy"), buff.BuffAmount);

        //calculate total buffs
        totalHPBuff = 0;
        foreach (float buffAmount in HPBuffAddition)
        {
            totalHPBuff += buffAmount;
        }
        foreach (float buffAmount in HPBuffMultiy)
        {
            totalHPBuff *= buffAmount;
        }
        totalDMGBuff = 0;
        foreach (float buffAmount in DMGBuffAddition)
        {
            totalDMGBuff += buffAmount;
        }
        foreach (float buffAmount in DMGBuffMultiy)
        {
            totalDMGBuff *= buffAmount;
        }
        totalAKTSpeedBuff = 0;
        foreach (float buffAmount in ATKSpeeedAddition)
        {
            totalAKTSpeedBuff += buffAmount;
        }
        foreach (float buffAmount in ATKSpeeedMultiy)
        {
            totalAKTSpeedBuff *= buffAmount;
        }

        BattelControler.Instance.Player.addBuff(totalHPBuff, totalDMGBuff, totalAKTSpeedBuff);
    }

    public void addToListX(string ListName, float buffAmount)
    {
        switch (ListName)
        {
            case "HP Buff Addition":
                HPBuffAddition.Add(buffAmount);
                break;
            case "DMG Buff Addition":
                DMGBuffAddition.Add(buffAmount);
                break;
            case "AKT Speed Buff Addition":
                ATKSpeeedAddition.Add(buffAmount);
                break;
            case "HP Buff Multiy":
                HPBuffMultiy.Add(buffAmount);
                break;
            case "DMG Buff Multiy":
                DMGBuffMultiy.Add(buffAmount);
                break;
            case "AKT Speed Buff Multiy":
                ATKSpeeedMultiy.Add(buffAmount);
                break;
        }
    }

}
