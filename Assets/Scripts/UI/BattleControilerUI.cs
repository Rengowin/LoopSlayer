using UnityEngine;
using System.Collections.Generic;

public class BattleUIController : MonoBehaviour
{
    public static BattleUIController Instance { get; private set; }

    [Header("Enemy UI")]
    [SerializeField]
    Transform enemyUIContainer;
    [SerializeField]
    GameObject enemyUIPrefab;

    [Header("Player UI")]
    [SerializeField]
    Transform playerUIContainer;
    [SerializeField]
    GameObject playerUIPrefab;

    [Header("Manuelle UI Positionen für Gegner")]
    public List<Vector2> enemyUIPositions = new List<Vector2>();

    [Header("Manuelle UI Positionen für Spieler")]
    public List<Vector2> playerUIPositions = new List<Vector2>();

    int enemyIndex = 0;
    int playerIndex = 0;
    GameObject currentPlayerUI;

    [SerializeField]
    List<RectTransform> enemyPos = new List<RectTransform>();

    [SerializeField]
    RectTransform playerPos;

    void Awake()
    {
        Instance = this;
    }

    public GameObject CreateEnemyUIAndReturn(Enemy enemy)
    {
        GameObject ui = Instantiate(enemyUIPrefab, enemyUIContainer);
        RectTransform rt = ui.GetComponent<RectTransform>();

        if (enemyIndex < enemyPos.Count && enemyPos[enemyIndex] != null)
        {
            rt.position = enemyPos[enemyIndex].position;
        }
        else
        {
            Debug.LogWarning($"Keine Enemy-UI-Position für Index {enemyIndex} vorhanden.");
        }

        CharacterUIController controller =
            ui.GetComponent<CharacterUIController>();

        controller.InitEnemy(enemy);

        enemyIndex++;
        return ui;
    }

    public void RemoveEnemyUI(GameObject uiGO)
    {
        Destroy(uiGO);
    }

    private void RearrangeEnemyUI()
    {
        enemyIndex = 0;

        foreach (Transform child in enemyUIContainer)
        {
            if (enemyIndex >= enemyPos.Count)
            {
                Debug.LogWarning(
                    $"Keine Enemy-UI-Position für Index {enemyIndex} vorhanden."
                );
                break;
            }

            RectTransform rt = child.GetComponent<RectTransform>();
            RectTransform target = enemyPos[enemyIndex];

            if (rt != null && target != null)
            {
                rt.position = target.position;
            }

            enemyIndex++;
        }
    }

    public GameObject CreatePlayerUI(Player player)
    {
        if (currentPlayerUI != null)
            Destroy(currentPlayerUI);

        GameObject ui = Instantiate(playerUIPrefab, playerUIContainer);
        currentPlayerUI = ui;

        RectTransform rt = ui.GetComponent<RectTransform>();

        if (playerPos != null)
        {
            rt.position = playerPos.position;
        }
        else
        {
            Debug.LogWarning("Keine Player-UI-Position gesetzt.");
        }

        CharacterUIController controller =
            ui.GetComponent<CharacterUIController>();

        controller.InitPlayer(player);

        return ui;
    }

    public void RemovePlayerUI()
    {
        if (currentPlayerUI != null)
        {
            Destroy(currentPlayerUI);
            currentPlayerUI = null;
        }
    }

    public void ResetEnemyUIIndex()
    {
        enemyIndex = 0;

        foreach (Transform child in enemyUIContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
