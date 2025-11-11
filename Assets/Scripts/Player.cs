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

    float currentActionTimer;

    bool isAlive = true;

    public float HP
    {
        get => hp;
        set
        {
            hp = value;
            if(hp <= 0)
            {
                isAlive = false;
                hp = 0;
                Debug.Log("Player is dead.");
            }
        }
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
        Debug.Log("Kann Aangreifen");
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
}
