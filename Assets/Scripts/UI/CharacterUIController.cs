using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider hpBar;
    [SerializeField] private TextMeshProUGUI infoText;

    private Enemy enemy;
    private Player player;

    private float maxHP;

    // ---------------------------------------------------------
    // INIT FOR ENEMY (STATIC UI)
    // ---------------------------------------------------------
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

    // ---------------------------------------------------------
    // INIT FOR PLAYER (STATIC UI)
    // ---------------------------------------------------------
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

    // ---------------------------------------------------------
    // UPDATE UI
    // ---------------------------------------------------------
    void Update()
    {
        if (player != null)
        {
            // Max HP live synchronisieren
            if (hpBar.maxValue != player.MaxHPValue)
                hpBar.maxValue = player.MaxHPValue;

            // Aktuelles HP setzen
            hpBar.value = player.currentHP;
        }
        if (enemy != null)
            hpBar.value = enemy.HP;

        if (player != null)
            hpBar.value = player.currentHP;
    }
}
