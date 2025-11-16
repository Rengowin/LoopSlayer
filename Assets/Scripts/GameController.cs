using UnityEngine;

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
    int score =0; // Score-Variable hinzugefügt

    bool isPause = false;
    bool spawnsAktiv = true;

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
            mainUIController.Score = score; // UI aktualisieren
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = BattelControler.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {

        HighscoreManager.Instance.AddScore(score);
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over!");
    

    }

// Upgrade-Punkte hinzufügen
public void AddUpgradePoints(int amount)
    {
        upgradePoints += amount;
        mainUIController.UpdateUpgradePoints(upgradePoints); // UI aktualisieren
    }

    // Upgrade-Punkte ausgeben
    public bool SpendUpgradePoints(int amount)
    {
        if (upgradePoints >= amount)
        {
            upgradePoints -= amount;
            mainUIController.UpdateUpgradePoints(upgradePoints); // UI aktualisieren
            return true;
        }
        return false; // Nicht genug Punkte
    }

    // Aktuelle Upgrade-Punkte abfragen
    public int GetUpgradePoints()
    {
        return upgradePoints;
    }

    public void AddScore(int amount)
    {
        Score += amount; // Score erhöhen
    }
}
