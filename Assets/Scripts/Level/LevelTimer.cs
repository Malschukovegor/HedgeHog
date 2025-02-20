using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float levelTime; // Время прохождения уровня
    private bool isLevelCompleted = false; // Флаг завершения уровня

    void Update()
    {
        if (!isLevelCompleted)
        {
            // Обновляем время, пока уровень не завершен
            levelTime += Time.deltaTime;
        }
    }

    public void CompleteLevel(int levelIndex)
    {
        if (!isLevelCompleted)
        {
            isLevelCompleted = true; // Уровень завершен

            // Получаем текущее лучшее время для уровня
            float bestTime = PlayerPrefs.GetFloat("Level" + levelIndex + "Time", float.MaxValue);

            // Если текущее время лучше, сохраняем его
            if (levelTime < bestTime)
            {
                PlayerPrefs.SetFloat("Level" + levelIndex + "Time", levelTime);
                PlayerPrefs.Save(); // Сохраняем данные на диск
                Debug.Log("Новый рекорд для уровня " + levelIndex + ": " + levelTime);
            }
        }
    }
}
