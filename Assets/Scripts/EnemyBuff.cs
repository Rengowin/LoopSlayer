using UnityEngine;

public class EnemyBuff : BuffsThatIGet
{
    [SerializeField]
    private float baseHp, baseDmg, baseAktSpeed;

    private int hp, dmg;
    private float aktSpeed;

    // Gegner-spezifische Buff-Logik
    public void ApplyEnemyBuffs()
    {
        // Beispiel: Gegner-spezifische Buff-Logik
        Debug.Log("Gegner-Buffs werden angewendet.");
    }
}