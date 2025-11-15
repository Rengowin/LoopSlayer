using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [SerializeField]
    Slider hpBar;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI upgradePointsText;

    [SerializeField]
    Button pauseButton;
    [SerializeField]
    Button menuButton;
    [SerializeField]
    Button upgradeMenuButton;

    [SerializeField]
    GameObject upgradeMenuPanel; // Das Panel für das Upgrade-Menü

    string scoreTextPrefix = "Score: ";
    string upgradePointsTextPrefix = "Upgrade Points: ";

    int score = 0;
    int upgradePoints = 0;

    float playerHP = 0;

    bool toogleToPause = false;
    bool toogleToDefeat = false;
    bool battleStartet = false;

    //getters and setters
    public int Score { get => score; set => score = value; }
    public int UpgradePoints { get => upgradePoints; set => upgradePoints = value; }

    public float PlayerHP { get => playerHP; set => playerHP = value; }

    public bool ToogleToPause { get => toogleToPause; set => toogleToPause = value; }
    public bool ToogleToDefeat { get => toogleToDefeat; set => toogleToDefeat = value; }
    public bool BattleStartet { get => battleStartet; set => battleStartet = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Upgrade-Menü standardmäßig ausblenden
        upgradeMenuPanel.SetActive(false);

        // Button-Listener hinzufügen
        upgradeMenuButton.onClick.AddListener(ToggleUpgradeMenu);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UPdateHP(float hp)
    {
        hpBar.value = hp;
    }

    public void UpdateMaxHP(float maxHp)
    {
        hpBar.maxValue = maxHp;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = scoreTextPrefix + score.ToString();
    }

    public void UpdateUpgradePoints(int upgradePoints)
    {
        upgradePointsText.text = upgradePointsTextPrefix + upgradePoints.ToString();
    }

    // Upgrade-Menü ein-/ausblenden
    void ToggleUpgradeMenu()
    {
        bool isActive = upgradeMenuPanel.activeSelf;
        upgradeMenuPanel.SetActive(!isActive); // Zustand umkehren
    }
}
