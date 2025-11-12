using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    int upgradePoints;

    public int UpgradePoints
    {
        get => upgradePoints;
        set => upgradePoints = value;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void getUpgratePoint(int amount)
    {
        upgradePoints++;
    }
}
