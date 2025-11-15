using UnityEngine;
using System.Collections.Generic;

public class BattleUIController : MonoBehaviour
{
    public static BattleUIController Instance { get; private set; }

    [Header("Enemy UI")]
    [SerializeField] private Transform enemyUIContainer;
    [SerializeField] private GameObject enemyUIPrefab;

    [Header("Player UI")]
    [SerializeField] private Transform playerUIContainer;
    [SerializeField] private GameObject playerUIPrefab;

    [Header("Manuelle UI Positionen für Gegner")]
    public List<Vector2> enemyUIPositions = new List<Vector2>();

    [Header("Manuelle UI Positionen für Spieler")]
    public List<Vector2> playerUIPositions = new List<Vector2>();

    private int enemyIndex = 0;
    private int playerIndex = 0;
    private GameObject currentPlayerUI;

    void Awake()
    {
        Instance = this;
    }

    // -------------------------------------------------------
    // ENEMY UI MIT MANUELLER POSITION
    // -------------------------------------------------------
    public GameObject CreateEnemyUIAndReturn(Enemy enemy)
    {
        GameObject ui = Instantiate(enemyUIPrefab, enemyUIContainer);
        RectTransform rt = ui.GetComponent<RectTransform>();

        rt.anchorMin = new Vector2(1, 1);
        rt.anchorMax = new Vector2(1, 1);
        rt.pivot = new Vector2(1, 1);

        if (enemyIndex < enemyUIPositions.Count)
            rt.anchoredPosition = enemyUIPositions[enemyIndex];
        else
            rt.anchoredPosition = new Vector2(-20, -enemyIndex * 150f);

        var controller = ui.GetComponent<CharacterUIController>();
        controller.InitEnemy(enemy);

        enemyIndex++;
        return ui;
    }

    public void RemoveEnemyUI(GameObject uiGO)
    {
        Destroy(uiGO);
        enemyIndex--;

        // UI-Container neu sortieren
        RearrangeEnemyUI();
    }

    private void RearrangeEnemyUI()
    {
        enemyIndex = 0;

        foreach (Transform child in enemyUIContainer)
        {
            RectTransform rt = child.GetComponent<RectTransform>();

            if (enemyIndex < enemyUIPositions.Count)
            {
                rt.anchoredPosition = enemyUIPositions[enemyIndex];
            }
            else
            {
                rt.anchoredPosition = new Vector2(-20, -enemyIndex * 150f);
            }

            enemyIndex++;
        }
    }


    // -------------------------------------------------------
    // PLAYER UI MIT MANUELLER POSITION
    // -------------------------------------------------------
    public GameObject CreatePlayerUI(Player player)
    {
        // wenn noch ein altes UI existiert → löschen
        if (currentPlayerUI != null)
            Destroy(currentPlayerUI);

        GameObject ui = Instantiate(playerUIPrefab, playerUIContainer);
        currentPlayerUI = ui; // speichern!

        RectTransform rt = ui.GetComponent<RectTransform>();

        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);

        if (playerUIPositions.Count > 0)
            rt.anchoredPosition = playerUIPositions[0];
        else
            rt.anchoredPosition = new Vector2(20f, -20f);

        var controller = ui.GetComponent<CharacterUIController>();
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

        // optional: UI löschen aus Container
        foreach (Transform child in enemyUIContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
