using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    UpgradeController upgradeController;

    public static UpgradeManager Instance;
    [Header("Upgrade Pool")]
    [SerializeField]
    List<BuffClass> PossibleUpgrades = new List<BuffClass>();

    [Header("Max Upgrade Counts")]
    [SerializeField]
    int maxATKSpeedUpgrades;
    [SerializeField]
    int maxATKCountUpgrades;

    [Header("Enemy/Spawn Caps (Inspector gesteuert)")]
    [SerializeField]
    float maxEnemyScaleReduction;
    [SerializeField]
    float maxSpawnIntervalReduction;

    [Header("UI References")]
    [SerializeField]
    GameObject upgradeButtonPrefab;
    [SerializeField]
    GameObject upgradeButtonContainer;

    bool canInitialize = false;
    bool isInitialized = false;

    int currentATKSpeedUpgrades = 0;
    int currentATKCountUpgrades = 0;

    List<UpgradeButtonScript> upgradeButtons = new List<UpgradeButtonScript>();

    List<float> HPBuffAddition = new List<float>();
    List<float> HPBuffMultiy = new List<float>();

    List<float> DMGBuffAddition = new List<float>();
    List<float> DMGBuffMultiy = new List<float>();

    List<float> HealAmountAddition = new List<float>();
    List<float> HealAmountMultiy = new List<float>();

    List<float> MovementSpeedAddition = new List<float>();

    List<float> ATKSpeedAddition = new List<float>();
    List<float> ATKCountAddition = new List<float>();

    List<float> SpawnChanceReductionPrefab0 = new List<float>();
    List<float> SpawnChanceAdditionPrefab1 = new List<float>();
    List<float> SpawnChanceAdditionPrefab2 = new List<float>();
    List<float> SpawnChanceAdditionPrefab3 = new List<float>();

    List<float> SpawnIntervalReduction = new List<float>();

    List<float> EnemyScaleReduction = new List<float>();

    float totalHPBuff = 0;
    float totalDMGBuff = 0;
    float totalHealAmountBuff = 0;
    float totalMovementSpeedBuff = 0;
    float totalATKSpeedBuff = 0;
    float totalATKCountBuff = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        foreach (BuffClass buff in PossibleUpgrades)
        {
            createBuffButtons(buff);
        }
    }

    public void createBuffButtons(BuffClass buffInfo)
    {
        GameObject obj = Instantiate(upgradeButtonPrefab);
        obj.transform.SetParent(upgradeButtonContainer.transform, false);

        var script = obj.GetComponent<UpgradeButtonScript>();
        if (script != null)
        {
            script.Init(buffInfo, this, upgradeController);
        }
        else
        {
            Debug.LogError("UpgradeButtonScript konnte nicht gefunden werden.");
        }
    }

    public void addToListX(string ListName, float buffAmount)
    {

        switch (ListName)
        {
            case "HP Addition":
                HPBuffAddition.Add(buffAmount);
                break;

            case "DMG Addition":
                DMGBuffAddition.Add(buffAmount);
                break;

            case "HealAmount Addition":
                HealAmountAddition.Add(buffAmount);
                break;

            case "MovementSpeed Addition":
                MovementSpeedAddition.Add(buffAmount);
                break;

            case "ATKSpeed Addition":
                if (currentATKSpeedUpgrades < maxATKSpeedUpgrades)
                {
                    ATKSpeedAddition.Add(buffAmount);
                    currentATKSpeedUpgrades++;
                }
                break;

            case "ATKCount Addition":
                if (currentATKCountUpgrades < maxATKCountUpgrades)
                {
                    ATKCountAddition.Add(buffAmount);
                    currentATKCountUpgrades++;
                }
                break;


            case "SpawnChance Reduction Prefab0 Addition":
                SpawnChanceReductionPrefab0.Add(buffAmount);
                break;

            case "SpawnChance Prefab1 Addition":
                SpawnChanceAdditionPrefab1.Add(buffAmount);
                break;

            case "SpawnChance Prefab2 Addition":
                SpawnChanceAdditionPrefab2.Add(buffAmount);
                break;

            case "SpawnChance Prefab3 Addition":
                SpawnChanceAdditionPrefab3.Add(buffAmount);
                break;


            case "SpawnInterval Reduction Addition":
                SpawnIntervalReduction.Add(buffAmount);
                break;


            case "EnemyScaleReduce Addition":
                EnemyScaleReduction.Add(buffAmount);
                break;

            case "HP Multiy":
                HPBuffMultiy.Add(buffAmount);
                break;

            case "DMG Multiy":
                DMGBuffMultiy.Add(buffAmount);
                break;

            case "HealAmount Multiy":
                HealAmountMultiy.Add(buffAmount);
                break;


            default:
                Debug.LogError($"Unknown buff list: {ListName}");
                break;
        }
    }

    public void applyBuff(BuffClass buff)
    {
        string key = buff.BuffName + (buff.BuffAddtive ? " Addition" : " Multiy");
        addToListX(key, buff.BuffAmount);

        float totalHPAddition = SumList(HPBuffAddition);
        float totalHPMultiplier = CalculateMultiplier(HPBuffMultiy);
        
        float totalDMGAddition = SumList(DMGBuffAddition);
        float totalDMGMultiplier = CalculateMultiplier(DMGBuffMultiy);
        
        float totalHealAmountAddition = SumList(HealAmountAddition);
        float totalHealAmountMultiplier = CalculateMultiplier(HealAmountMultiy);
        
        totalMovementSpeedBuff = CalculateTotalBuff(MovementSpeedAddition, null);
        totalATKSpeedBuff = CalculateTotalBuff(ATKSpeedAddition, null);
        totalATKCountBuff = CalculateTotalBuff(ATKCountAddition, null);

        if (BattelControler.Instance?.Player != null)
        {
            BattelControler.Instance.Player.ApplyBuffs(
                totalHPAddition,
                totalHPMultiplier,
                totalDMGAddition,
                totalDMGMultiplier,
                totalATKSpeedBuff,
                totalHealAmountAddition,
                totalHealAmountMultiplier,
                totalMovementSpeedBuff,
                (int)totalATKCountBuff
            );
        }

        float spawnIntervalReduction = SumList(SpawnIntervalReduction);
        spawnIntervalReduction = Mathf.Min(spawnIntervalReduction, maxSpawnIntervalReduction);

        GameController.Instance.SpawnManager.ApplySpawnIntervalReduction(spawnIntervalReduction);

        float scaleReduction = SumList(EnemyScaleReduction);
        scaleReduction = Mathf.Min(scaleReduction, maxEnemyScaleReduction);

        GameController.Instance.SpawnManager.ApplyEnemyScaleReduction(scaleReduction);

        float t0 = SumList(SpawnChanceReductionPrefab0);
        float t1 = SumList(SpawnChanceAdditionPrefab1);
        float t2 = SumList(SpawnChanceAdditionPrefab2);
        float t3 = SumList(SpawnChanceAdditionPrefab3);

        GameController.Instance.SpawnManager.ApplySpawnChanceChanges(t0, t1, t2, t3);
    }

    float CalculateTotalBuff(List<float> addList, List<float> multiList)
    {
        float add = SumList(addList);
        float multi = 1f;

        if (multiList != null)
        {
            foreach (var m in multiList) multi *= m;
        }

        return add * multi;
    }

    float CalculateMultiplier(List<float> multiList)
    {
        float multi = 1f;

        if (multiList != null)
        {
            foreach (var m in multiList) multi *= m;
        }

        return multi;
    }

    float SumList(List<float> list)
    {
        float sum = 0;
        foreach (var v in list) sum += v;
        return sum;
    }
}
