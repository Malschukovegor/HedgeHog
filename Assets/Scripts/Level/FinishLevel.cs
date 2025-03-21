using UnityEngine;
using TMPro;

public class FinishLevel : MonoBehaviour
{
    public string nextLevelName; // Имя следующего уровня
    public LevelTimer levelTimer; // Ссылка на скрипт LevelTimer
    public int levelIndex = 1;
    public GameObject finishMenu;
    public GameObject finishMenuLastLevel;
    public AudioClip finishSound;
    private AudioSource audioSource;
    private GameObject timer;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timer = GameObject.Find("Timer");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            finishMenu.SetActive(false);
            finishMenuLastLevel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (CoinManager.Instance.collectedCoins >= CoinManager.Instance.totalCoins)
            {
                CompleteLevel();
                levelTimer.CompleteLevel(levelIndex); // Сохраняем время уровня
            }
        }
    }

    void CompleteLevel()
    {
        // Показываем сообщение о завершении уровня
        Debug.Log("Level Complete!");

        if (!string.IsNullOrEmpty(nextLevelName))
        {
            ShowFinishMenu();
            timer.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Next level name is not set!");
        }
    }
    void ShowFinishMenu()
    {
        audioSource.PlayOneShot(finishSound);
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        Time.timeScale = 0.0f;
        
        if (levelIndex == 3)
        {
            finishMenuLastLevel.SetActive(true);
        }
        else
        {
            finishMenu.SetActive(true);
        }
    }
}
