using UnityEngine;
using TMPro;

public class HighscoreMenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    bool initialized = false;

    private void OnEnable()
    {
        initialized = false;
        UpdateHighscoreList();
    }

    private void Update()
    {
        // Solange kein HighscoreManager da ist → erneut versuchen
        if (!initialized)
            UpdateHighscoreList();
    }

    void UpdateHighscoreList()
    {
        var manager = HighscoreManager.Instance;

        if (manager == null)
        {
            scoreText.text = "Loading...";
            return; // noch nicht fertig → Update versucht später nochmal
        }

        var scores = manager.Scores;

        if (scores == null || scores.Count == 0)
        {
            scoreText.text = "No scores yet!";
            initialized = true; // UI fertig
            return;
        }

        scoreText.text = "";

        for (int i = 0; i < scores.Count; i++)
            scoreText.text += $"{i + 1}. {scores[i]}\n";

        initialized = true; // ab jetzt keine Updates mehr nötig
    }
}
