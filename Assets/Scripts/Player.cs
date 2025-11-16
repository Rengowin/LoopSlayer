using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float dmg;
    [SerializeField] float speed;
    [SerializeField] float aktSpeed;
    [SerializeField] int atkCount;
    [SerializeField] int maxHP;
    [SerializeField] float healAmount;
    [SerializeField] float healSpeed;

    float currentActionTimer;

    // === Base Werte für Buff-System ===
    float baseMaxHP;
    float baseDMG;
    float baseSpeed;
    float baseATKSpeed;
    int baseATKCount;
    float baseHealAmount;

    // === Properties (UNVERÄNDERT) ===
    public float currentHP
    {
        get => hp;
        set
        {
            hp = value;
            GameController.Instance.MainUIController.PlayerHP = hp;

            if (hp <= 0)
            {
                GameController.Instance.GameOver();
                hp = 0;
                Debug.Log("Player is dead.");
            }
        }
    }

    public int MaxHPValue
    {
        get => maxHP;
        set => maxHP = value;
    }

    public float Dmg
    {
        get => dmg;
        set => dmg = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float AKTSpeed
    {
        get => aktSpeed;
        set => aktSpeed = value;
    }

    public int ATKCount
    {
        get => atkCount;
        set => atkCount = value;
    }

    public float HealAmount
    {
        get => healAmount;
        set => healAmount = value;
    }

    public float HealSpeed
    {
        get => healSpeed;
        set => healSpeed = value;
    }

    void Start()
    {
        currentActionTimer = aktSpeed;

        // ==== Base Werte speichern ====
        baseMaxHP = maxHP;
        baseDMG = dmg;
        baseSpeed = speed;
        baseATKSpeed = aktSpeed;
        baseATKCount = atkCount;
        baseHealAmount = healAmount;
    }

    public void UpdateActionTimer(float deltatime)
    {
        currentActionTimer -= deltatime;
    }

    public bool IsActionReady()
    {
        return currentActionTimer <= 0;
    }

    public void ResetActionTimer()
    {
        currentActionTimer = aktSpeed;
    }

    // ============================================================
    //                BUFF-UPDATE (keine Doppel-Additionen)
    // ============================================================
    public void ApplyBuffs(
        float hpBuff,
        float dmgBuff,
        float atkSpeedBuff,
        float healBuff,
        float movementBuff,
        int atkCountBuff)
    {
        // HP
        maxHP = (int)(baseMaxHP + hpBuff);

        if (currentHP > maxHP)
            currentHP = maxHP;

        // Damage
        dmg = baseDMG + dmgBuff;

        // Movement
        speed = baseSpeed + movementBuff;

        // ATK Speed (Buff = schneller → aktSpeed wird kleiner)
        aktSpeed = Mathf.Max(0.1f, baseATKSpeed - atkSpeedBuff);

        // ATK Count
        atkCount = baseATKCount + atkCountBuff;

        // Heal amount
        healAmount = baseHealAmount + healBuff;

        Debug.Log($"[Player Buffs] HP:{maxHP} DMG:{dmg} SPD:{speed} ATKSPD:{aktSpeed} COUNT:{atkCount}");
    }

    public void Heal()
    {
        hp = Mathf.Min(hp + healAmount, maxHP);
    }
}
