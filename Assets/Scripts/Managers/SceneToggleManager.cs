using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToggleManager : MonoBehaviour
{
    public static SceneToggleManager Instance { get; private set; }

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
            StartCoroutine(WaitForSpawnManagerAndTriggerSpawn());
        }
    }

    private System.Collections.IEnumerator WaitForSpawnManagerAndTriggerSpawn()
    {
        yield return null;

        float timeout = 2f;
        float start = Time.realtimeSinceStartup;
        Spawn2DManager mgr = null;

        while (Time.realtimeSinceStartup - start < timeout)
        {
            mgr = FindObjectOfType<Spawn2DManager>();
            if (mgr != null) break;
            yield return null;
        }

        if (mgr == null)
        {
            Debug.LogError("SceneToggleManager: Spawn2DManager nicht gefunden nach Laden der Fight-Szene (Timeout).");
            yield break;
        }

        if (BattelControler.Instance != null)
            BattelControler.Instance.spawnEnemysAfterSecenLoad();
        else
            Debug.LogError("SceneToggleManager: BattelControler.Instance ist null.");
    }
}
