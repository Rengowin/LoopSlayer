using UnityEngine;
using TMPro;

public class HighscoreMenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int maxEntries; // Maximale Anzahl der angezeigten Highscores
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

        // Begrenze die Anzahl der angezeigten Highscores auf maxEntries
        for (int i = 0; i < Mathf.Min(scores.Count, maxEntries); i++)
        {
            scoreText.text += $"{i + 1}. {scores[i]}\n";
        }

        initialized = true; // ab jetzt keine Updates mehr nötig
    }
}
