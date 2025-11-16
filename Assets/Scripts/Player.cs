using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float hp;
    [SerializeField]
    float dmg;
    [SerializeField]
    float speed;
    [SerializeField]
    float aktSpeed;
    [SerializeField]
    int atkCount;
    [SerializeField]
    int maxHP;
    [SerializeField]
    float healAmount;
    [SerializeField]
    float healSpeed;

    float currentActionTimer;

    float totalHPBuff, totalDMGBuff, totalAKTSpeedBuff;

    bool healAktive = true;

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

    public bool HealAktive
    {
        get => healAktive;
        set => healAktive = value;
    }

    public int MaxHPValue
    {
        get => maxHP;
        set => maxHP = value;
    }

    public float Dmg
    {
        get => dmg; set => dmg = value;
    }

    public float Speed
    {
        get => speed; set => speed = value;
    }
    public float AKTSpeed
    {
        get => aktSpeed; set => aktSpeed = value;
    }
    public int ATKCount
    {
        get => atkCount; set => atkCount = value;
    }

    public float HealAmount
    {
        get => healAmount; set => healAmount = value;
    }
    public float HealSpeed
    {
        get => healSpeed; set => healSpeed = value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentActionTimer = aktSpeed;
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

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBuff(float hpBuff, float dmgBuff, float atkSpeedBuff)
    {
        if (totalHPBuff != hpBuff || totalDMGBuff != dmgBuff || totalAKTSpeedBuff != atkSpeedBuff)
        {
            if (totalHPBuff != hpBuff)
            {
                totalHPBuff = hpBuff;
                maxHP = (int)(maxHP + totalHPBuff);
                currentHP += hpBuff;
            }

            if (totalDMGBuff != dmgBuff)
            {
                totalDMGBuff = dmgBuff;
                dmg += totalDMGBuff;
            }

            if (totalAKTSpeedBuff != atkSpeedBuff)
            {
                totalAKTSpeedBuff = atkSpeedBuff;
                aktSpeed -= totalAKTSpeedBuff;
                if (aktSpeed < 0.1f)
                {
                    aktSpeed = 0.1f;
                }
            }
        }
    }
}
