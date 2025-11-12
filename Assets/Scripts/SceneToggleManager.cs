using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToggleManager : MonoBehaviour
{
    public static SceneToggleManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadFightScene()
    {
        SceneManager.sceneLoaded += OnFightSceneLoaded;
        SceneManager.LoadScene("Fight", LoadSceneMode.Additive);
    }

    public void UnloadFightScene()
    {
        SceneManager.UnloadSceneAsync("Fight");
    }

    public void LoadPauseScene()
    {
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    public void UnloadPauseScene()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


    private void OnFightSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Fight")
        {
            SceneManager.sceneLoaded -= OnFightSceneLoaded;
            BattelControler.Instance.spawnEnemysAfterSecenLoad();
        }
    }
}
