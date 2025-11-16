using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameBoard");
        });

        quitButton.onClick.AddListener(() =>
        {
            Debug.Log("Quit Game");
            Application.Quit();
        });
    }
}
