using UnityEngine;

public class PlayerBuff : BuffsThatIGet
{
    [SerializeField]
    private float baseHp, baseDmg, baseAktSpeed;

    private int hp, dmg;
    private float aktSpeed;

    // Spieler-spezifische Buff-Logik
    public void ApplyPlayerBuffs()
    {
        // Beispiel: Spieler-spezifische Buff-Logik
        Debug.Log("Spieler-Buffs werden angewendet.");
    }
}