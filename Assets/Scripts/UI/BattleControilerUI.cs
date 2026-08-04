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

    //what i added after my 3rd project just to fix stuff with scale/ for portfolio purposes and to show growth? idk
    [SerializeField]
    List<RectTransform> enemyPos = new List<RectTransform>();

    [SerializeField]
    RectTransform playerPos;

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


    // it was used before ui fix since it help somehow :D, and it will stay in because if someone wants to see this code and since it was my first unity projekt stuff idk :D since portfolio purposes
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


    // -------------------------------------------------------
    // PLAYER UI MIT MANUELLER POSITION
    // -------------------------------------------------------
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

        // optional: UI löschen aus Container
        foreach (Transform child in enemyUIContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
