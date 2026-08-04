using UnityEngine;

public class UIVisibilityManager : MonoBehaviour
{
    public static UIVisibilityManager Instance;

    [Header("Normal Game UI")]
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject highscoreMenu;

    [Header("Fight UI")]
    [SerializeField] GameObject fightUI;
    [SerializeField] GameObject playerUIContainer;
    [SerializeField] GameObject enemyUIContainer;
    [SerializeField] GameObject battleUIController;

    [Header("PlayBoardRendererHider")]
    [SerializeField] PlayBoardRendererHider playBoardRendererHider;

    void Awake()
    {
        Instance = this;
    }

    // NORMALER SPIELMODUS
    public void ShowNormalUI()
    {
        // Normale UI sichtbar
        mainUI.SetActive(true);
        upgradeMenu.SetActive(false);
        highscoreMenu.SetActive(true);

        // Fight UI aus
        fightUI.SetActive(false);
        playerUIContainer.SetActive(false);
        enemyUIContainer.SetActive(false);
        battleUIController.SetActive(false);

        // 3D Welt sichtbar
        playBoardRendererHider.SetVisible(true);
    }

    // KAMPFMODUS
    public void ShowFightUI()
    {
        // Normale UI verstecken
        mainUI.SetActive(false);
        upgradeMenu.SetActive(false);
        highscoreMenu.SetActive(false);

        // Fight UI sichtbar
        fightUI.SetActive(true);
        playerUIContainer.SetActive(true);
        enemyUIContainer.SetActive(true);
        battleUIController.SetActive(true);

        // 3D Welt unsichtbar
        playBoardRendererHider.SetVisible(false);
    }
}
