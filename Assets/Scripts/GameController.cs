using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    PathManager pathManager;
    SpawnManager spawnManager;

    bool isPause = false;
    bool spawnsAktiv = true;
    public SpawnManager SpawnManager
        {get => spawnManager; }
    public PathManager PathManager { get => pathManager; }

    public bool spawnActiv
    {
        get => spawnsAktiv;
        set => spawnsAktiv = value;
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
        pathManager = FindObjectOfType<PathManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
