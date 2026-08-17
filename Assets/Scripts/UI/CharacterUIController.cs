using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    Slider hpBar;
    [SerializeField]
    TextMeshProUGUI infoText;

    Enemy enemy;
    Player player;

    float maxHP;

    public void InitEnemy(Enemy enemy)
    {
        this.enemy = enemy;

        maxHP = enemy.HP;
        hpBar.maxValue = maxHP;
        hpBar.value = enemy.HP;

        infoText.text =
            $"Enemy: {enemy.Name}\n" +
            $"DMG: {enemy.DMG}\n" +
            $"ATK SPD: {enemy.AktSpeed}\n" +
            $"Score: {enemy.ScoreOneKill}";
    }

    public void InitPlayer(Player player)
    {
        this.player = player;

        maxHP = player.MaxHPValue;
        hpBar.maxValue = maxHP;
        hpBar.value = player.currentHP;

        infoText.text =
            $"Player\n" +
            $"DMG: {player.Dmg}\n" +
            $"ATK SPD: {player.AKTSpeed}\n" +
            $"MaxHP: {player.MaxHPValue}";
    }

    void Update()
    {
        if (player != null)
        {
            if (hpBar.maxValue != player.MaxHPValue)
                hpBar.maxValue = player.MaxHPValue;

            hpBar.value = player.currentHP;
        }
        if (enemy != null)
            hpBar.value = enemy.HP;

        if (player != null)
            hpBar.value = player.currentHP;
    }
}
