using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Für Szenenwechsel hinzufügen

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
    [SerializeField]
    GameObject pauseMenuPanel; // Das Panel für das Pause-Menü

    [SerializeField]
    UpgradeController upgradeController; // Hinzugefügt, um UpgradeController zu referenzieren

    [SerializeField]
    GameController gameController; // Hinzugefügt, um GameController zu referenzieren

    string scoreTextPrefix = "Score: ";
    string upgradePointsTextPrefix = "Upgrade Points: ";

    int score = 0;
    int upgradePoints = 0;

    float playerHP = 0;

    bool aktivemovement = true;
    bool aktivHeal = true;
    bool aktivSpawn = true;

    bool toogleToPause = false;
    bool toogleToDefeat = false;
    bool battleStartet = false;
    bool isPaused = false;

    //getters and setters

    public bool ToogleToPause { get => toogleToPause; set => toogleToPause = value; }
    public bool ToogleToDefeat { get => toogleToDefeat; set => toogleToDefeat = value; }
    public bool BattleStartet { get => battleStartet; set => battleStartet = value; }
    public int Score { get => score; set => score = value; } // Hinzugefügt, um die Score-Eigenschaft bereitzustellen
    public float PlayerHP { get => playerHP; set => playerHP = value; }

    // Temporäre Variable für die ursprüngliche Geschwindigkeit
    private float tempPlayerSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Upgrade-Menü standardmäßig ausblenden
        upgradeMenuPanel.SetActive(false);

        // Button-Listener hinzufügen
        upgradeMenuButton.onClick.AddListener(ToggleUpgradeMenu);

        // Pause-Menü standardmäßig ausblenden
        pauseMenuPanel.SetActive(false);

        // Button-Listener für Pause-Menü hinzufügen
        pauseButton.onClick.AddListener(TogglePauseMenu);

        // Button-Listener für Menü-Button hinzufügen
        menuButton.onClick.AddListener(LoadMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        // Spieler-HP aktualisieren
        if (BattelControler.Instance != null)
        {
            hpBar.value = BattelControler.Instance.Player.currentHP; // Korrektur: currentHP statt CurrentHP
            hpBar.maxValue = BattelControler.Instance.Player.MaxHPValue;
        }

        // Upgrade-Punkte aktualisieren
        if (upgradeController != null)
        {
            upgradePointsText.text = upgradePointsTextPrefix + upgradeController.UpgradePoints.ToString();
        }

        // Score aktualisieren
        if (gameController != null)
        {
            scoreText.text = scoreTextPrefix + gameController.MainUIController.Score.ToString();
        }
    }

    // Upgrade-Menü ein-/ausblenden
    void ToggleUpgradeMenu()
    {
        bool isActive = upgradeMenuPanel.activeSelf;
        upgradeMenuPanel.SetActive(!isActive); // Zustand umkehren
    }

    // Pause-Menü ein-/ausblenden
    void TogglePauseMenu()
    {

        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
           isPaused = false;
            Time.timeScale = 1f;
        }
        bool isActive = pauseMenuPanel.activeSelf;
        pauseMenuPanel.SetActive(!isActive); // Zustand umkehren

    }

    public void UpdateUpgradePoints(int upgradePoints)
    {
        upgradePointsText.text = upgradePointsTextPrefix + upgradePoints.ToString();
    }

    public void LoadMainMenu()
    {
        // Score nicht speichern und direkt zur Hauptmenüszene wechseln
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
