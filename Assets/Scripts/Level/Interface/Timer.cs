using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Используем TextMeshProUGUI для TMP
    public TextMeshProUGUI levelScore;
    public TextMeshProUGUI levelScoreEnd;
    private float startTime;
    private float lastUpdateTime; // Время последнего обновления текста

    void Start()
    {
        startTime = Time.time; // Запоминаем время старта уровня
        lastUpdateTime = 0f; // Инициализируем время последнего обновления
    }

    void Update()
    {
        float t = Time.time - startTime; // Вычисляем прошедшее время

        // Форматируем время: минуты, секунды, миллисекунды
        string minutes = ((int)t / 60).ToString("00"); // Минуты
        string seconds = (t % 60).ToString("00"); // Секунды
        string milliseconds = ((t * 100) % 100).ToString("00"); // Миллисекунды

        // Обновляем текст таймера
        timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        levelScore.text = "SCORE: " + timerText.text;
        levelScoreEnd.text = "SCORE: " + timerText.text;

        // Запоминаем время последнего обновления
        lastUpdateTime = t;
    }
}
