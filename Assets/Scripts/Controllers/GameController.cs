using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    MainUIController mainUIController;

    [SerializeField]
    PathManager pathManager;

    [SerializeField]
    SpawnManager spawnManager;

    [SerializeField]
    HighscoreManager highscoreManager;

    [SerializeField]
    GameObject gameOverPanel;

    Player player;

    int upgradePoints = 0;
    int score =0;

    bool isPause = false;
    bool spawnsAktiv = true;

    float gameOverTimer = -1f;


    public SpawnManager SpawnManager
        {get => spawnManager; }
    public PathManager PathManager 
    { get => pathManager; }

    public MainUIController MainUIController
    {
        get => mainUIController;
    }

    public HighscoreManager HighscoreManager
    {
        get => highscoreManager;
    }

    public bool spawnActiv
    {
        get => spawnsAktiv;
        set => spawnsAktiv = value;
    }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            mainUIController.Score = score;
        }
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        player = BattelControler.Instance.Player;
    }

    void Update()
    {
        if (gameOverTimer > 0)
        {
            gameOverTimer -= Time.deltaTime;
            if (gameOverTimer <= 0)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }

    public void GameOver()
    {
        HighscoreManager.Instance.AddScore(score);
        gameOverPanel.SetActive(true);

        Invoke(nameof(LoadMenuScene), 5f);
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void AddUpgradePoints(int amount)
    {
        upgradePoints += amount;
        mainUIController.UpdateUpgradePoints(upgradePoints);
    }

    public bool SpendUpgradePoints(int amount)
    {
        if (upgradePoints >= amount)
        {
            upgradePoints -= amount;
            mainUIController.UpdateUpgradePoints(upgradePoints);
            return true;
        }
        return false;
    }

    public int GetUpgradePoints()
    {
        return upgradePoints;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }
}
