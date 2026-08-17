using UnityEngine;

public class UIVisibilityManager : MonoBehaviour
{
    public static UIVisibilityManager Instance;

    [Header("Normal Game UI")]
    [SerializeField]
    GameObject mainUI;
    [SerializeField]
    GameObject upgradeMenu;
    [SerializeField]
    GameObject highscoreMenu;

    [Header("Fight UI")]
    [SerializeField]
    GameObject fightUI;
    [SerializeField]
    GameObject playerUIContainer;
    [SerializeField]
    GameObject enemyUIContainer;
    [SerializeField]
    GameObject battleUIController;

    [Header("PlayBoardRendererHider")]
    [SerializeField]
    PlayBoardRendererHider playBoardRendererHider;

    void Awake()
    {
        Instance = this;
    }

    public void ShowNormalUI()
    {
        mainUI.SetActive(true);
        upgradeMenu.SetActive(false);
        highscoreMenu.SetActive(true);

        fightUI.SetActive(false);
        playerUIContainer.SetActive(false);
        enemyUIContainer.SetActive(false);
        battleUIController.SetActive(false);

        playBoardRendererHider.SetVisible(true);
    }

    public void ShowFightUI()
    {
        mainUI.SetActive(false);
        upgradeMenu.SetActive(false);
        highscoreMenu.SetActive(false);

        fightUI.SetActive(true);
        playerUIContainer.SetActive(true);
        enemyUIContainer.SetActive(true);
        battleUIController.SetActive(true);

        playBoardRendererHider.SetVisible(false);
    }
}
