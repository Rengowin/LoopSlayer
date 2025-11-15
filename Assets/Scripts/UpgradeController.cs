using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{

    [SerializeField]
    int upgradePoints;

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
