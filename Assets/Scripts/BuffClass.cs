using UnityEngine;

[System.Serializable]
public class BuffClass
{
    [SerializeField]
    string buffName;
    [SerializeField]
    float buffAmount;

    [SerializeField]
    bool multiply, addtive;

    [SerializeField]
    int upgradeCost;

    public string BuffName { get => buffName; }
    public float BuffAmount { get => buffAmount; }
    public bool BuffAddtive { get => addtive; }
    public bool Multiply { get => multiply; }
    public int UpgradeCost { get => upgradeCost; }

}
