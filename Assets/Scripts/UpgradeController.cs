using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{

    [SerializeField]
    int upgradePoints;

    public static UpgradeController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public int UpgradePoints
    {
        get => upgradePoints;
        set => upgradePoints = value;
    }

    public void AddUpgradePoints(int amount)
    {
        upgradePoints += amount;
    }

}
