using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] Slider hpBar;

    private Enemy enemy;
    private Transform target;

    float enemyMaxHp;

    public void Init(Enemy enemy, Transform target) { 
        this.enemy = enemy;
        this.target = target;

        enemyMaxHp = enemy.HP;
        hpBar.maxValue = enemyMaxHp;
        hpBar.value = enemy.HP;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && target != null)
        {
            hpBar.value = enemy.HP;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + Vector3.up * 2);
            hpBar.transform.position = screenPos;
        }

        if(enemy == null || target == null)
        {
            Destroy(gameObject);
        }
    }
}
