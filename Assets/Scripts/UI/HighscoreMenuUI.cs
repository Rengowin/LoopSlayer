using UnityEngine;
using TMPro;

public class HighscoreMenuUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    int maxEntries;
    bool initialized = false;

    private void OnEnable()
    {
        initialized = false;
        UpdateHighscoreList();
    }

    private void Update()
    {
        if (!initialized)
            UpdateHighscoreList();
    }

    void UpdateHighscoreList()
    {
        var manager = HighscoreManager.Instance;

        if (manager == null)
        {
            scoreText.text = "Loading...";
            return;
        }

        var scores = manager.Scores;

        if (scores == null || scores.Count == 0)
        {
            scoreText.text = "No scores yet!";
            initialized = true;
            return;
        }

        scoreText.text = "";

        for (int i = 0; i < Mathf.Min(scores.Count, maxEntries); i++)
        {
            scoreText.text += $"{i + 1}. {scores[i]}\n";
        }

        initialized = true;
    }
}
