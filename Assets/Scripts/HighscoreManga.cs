using UnityEngine;
using System.Collections.Generic;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    const string SAVE_KEY = "highscores";

    public List<int> scores = new List<int>();

    public List<int> Scores => scores;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Load();
    }

    public void AddScore(int score)
    {
        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a));
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetString(SAVE_KEY, JsonUtility.ToJson(this));
        PlayerPrefs.Save();
    }

    void Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY)) return;
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(SAVE_KEY), this);
    }
}
