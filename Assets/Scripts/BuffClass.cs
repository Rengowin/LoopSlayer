using UnityEngine;

[System.Serializable]
public class BuffClass
{
    [SerializeField]
    string buffName;
    [SerializeField]
    float buffAmount;

    [SerializeField]
    bool buffAktive, playerOnly, enemyOnly, both;

    public string BuffName() => buffName;
    public float BuffAmount() => buffAmount;
    public bool BuffAktive() => buffAktive;
    public bool PlayerOnly() => playerOnly;
    public bool EnemyOnly() => enemyOnly;
    public bool Both() => both;


}
