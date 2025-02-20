using UnityEngine;
using TMPro;

public class HighScoresManafer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip resetHighScoreSound;
    public TextMeshProUGUI level1ScoreText; // Текстовое поле для уровня 1
    public TextMeshProUGUI level2ScoreText; // Текстовое поле для уровня 2
    public TextMeshProUGUI level3ScoreText; // Текстовое поле для уровня 3
    public TextMeshProUGUI totalScoreText;  // Текстовое поле для общего времени

    void Start()
    {
        UpdateHighScores(); // Загружаем и отображаем рекорды при старте меню
    }

    public void UpdateHighScores()
    {
        // Загружаем рекорды для каждого уровня
        float level1Time = PlayerPrefs.GetFloat("Level1Time", 0f);
        float level2Time = PlayerPrefs.GetFloat("Level2Time", 0f);
        float level3Time = PlayerPrefs.GetFloat("Level3Time", 0f);

        // Обновляем текстовые поля
        level1ScoreText.text = "LEVEL 1: " + FormatTime(level1Time);
        level2ScoreText.text = "LEVEL 2: " + FormatTime(level2Time);
        level3ScoreText.text = "LEVEL 3: " + FormatTime(level3Time);

        // Вычисляем общее время
        float totalTime = level1Time + level2Time + level3Time;
        totalScoreText.text = "TOTAL: " + FormatTime(totalTime);
    }

    private string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int milliseconds = (int)(time * 100) % 100;
        return $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }

    public void ResetHighScores()
    {
        audioSource.PlayOneShot(resetHighScoreSound);

        // Удаляем сохраненные рекорды
        PlayerPrefs.DeleteKey("Level1Time");
        PlayerPrefs.DeleteKey("Level2Time");
        PlayerPrefs.DeleteKey("Level3Time");

        // Сохраняем изменения
        PlayerPrefs.Save();

        // Обновляем текстовые поля
        UpdateHighScores();

        Debug.Log("Рекорды сброшены!");
    }
}
