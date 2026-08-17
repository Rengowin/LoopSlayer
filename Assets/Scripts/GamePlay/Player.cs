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

    float baseMaxHP;
    float baseDMG;
    float baseSpeed;
    float baseATKSpeed;
    int baseATKCount;
    float baseHealAmount;

    bool allreadyDead = false;

    public float currentHP
    {
        get => hp;
        set
        {
            hp = value;
            GameController.Instance.MainUIController.PlayerHP = hp;

            if (hp <= 0 && !allreadyDead)
            {
                allreadyDead = true;
                hp = 0;

                GameController.Instance.GameOver();
            }

            if(hp <= 0)
            {
                hp = 0;
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

    public void ApplyBuffs(
        float hpBuff,
        float dmgBuff,
        float atkSpeedBuff,
        float healBuff,
        float movementBuff,
        int atkCountBuff)
    {
        maxHP = (int)(baseMaxHP + hpBuff);

        if (currentHP > maxHP)
            currentHP = maxHP;

        dmg = baseDMG + dmgBuff;

        speed = baseSpeed + movementBuff;

        aktSpeed = Mathf.Max(0.1f, baseATKSpeed - atkSpeedBuff);

        atkCount = baseATKCount + atkCountBuff;

        healAmount = baseHealAmount + healBuff;
    }

    public void Heal()
    {
        hp = Mathf.Min(hp + healAmount, maxHP);
    }
}
