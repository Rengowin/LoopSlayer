using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    GameObject upgradeMenuPanel;
    [SerializeField]
    GameObject pauseMenuPanel; 

    [SerializeField]
    UpgradeController upgradeController;

    [SerializeField]
    GameController gameController;

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

    public bool ToogleToPause { get => toogleToPause; set => toogleToPause = value; }
    public bool ToogleToDefeat { get => toogleToDefeat; set => toogleToDefeat = value; }
    public bool BattleStartet { get => battleStartet; set => battleStartet = value; }
    public int Score { get => score; set => score = value; }
    public float PlayerHP { get => playerHP; set => playerHP = value; }

    private float tempPlayerSpeed;

    void Start()
    {
        upgradeMenuPanel.SetActive(false);

        upgradeMenuButton.onClick.AddListener(ToggleUpgradeMenu);

        pauseMenuPanel.SetActive(false);

        pauseButton.onClick.AddListener(TogglePauseMenu);

        menuButton.onClick.AddListener(LoadMainMenu);
    }

    void Update()
    {
        if (BattelControler.Instance != null)
        {
            hpBar.value = BattelControler.Instance.Player.currentHP;
            hpBar.maxValue = BattelControler.Instance.Player.MaxHPValue;
        }

        if (upgradeController != null)
        {
            upgradePointsText.text = upgradePointsTextPrefix + upgradeController.UpgradePoints.ToString();
        }

        if (gameController != null)
        {
            scoreText.text = scoreTextPrefix + gameController.MainUIController.Score.ToString();
        }
    }

    void ToggleUpgradeMenu()
    {
        bool isActive = upgradeMenuPanel.activeSelf;
        upgradeMenuPanel.SetActive(!isActive);
    }

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
        pauseMenuPanel.SetActive(!isActive);

    }

    public void UpdateUpgradePoints(int upgradePoints)
    {
        upgradePointsText.text = upgradePointsTextPrefix + upgradePoints.ToString();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
