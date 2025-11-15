using UnityEngine;

public class UIVisibilityManager : MonoBehaviour
{
    public static UIVisibilityManager Instance;

    [Header("Normal Game UI")]
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject highscoreMenu;

    [Header("PlayBoard Renderer Hider")]
    [SerializeField] PlayBoardRendererHider playBoard;

    [Header("Fight UI")]
    [SerializeField] GameObject fightUI;
    [SerializeField] GameObject playerUIContainer;
    [SerializeField] GameObject enemyUIContainer;
    [SerializeField] GameObject battleUIController;

    void Awake()
    {
        Instance = this;
    }

    public void ShowNormalUI()
    {
        mainUI.SetActive(true);
        highscoreMenu.SetActive(true);
        upgradeMenu.SetActive(false);

        // PlayBoard nur wieder sichtbar machen
        playBoard.SetVisible(true);

        fightUI.SetActive(false);
        playerUIContainer.SetActive(false);
        enemyUIContainer.SetActive(false);
        battleUIController.SetActive(false);
    }

    public void ShowFightUI()
    {
        mainUI.SetActive(false);
        highscoreMenu.SetActive(false);
        upgradeMenu.SetActive(false);

        // PlayBoard ausblenden (aber aktiv lassen!)
        playBoard.SetVisible(false);

        fightUI.SetActive(true);
        playerUIContainer.SetActive(true);
        enemyUIContainer.SetActive(true);
        battleUIController.SetActive(true);
    }
}
