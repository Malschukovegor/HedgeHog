using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public GameObject mainMenuPanel;
    public GameObject levelsPanel; // Ссылка на панель выбора уровней
    public GameObject highScoresPanel; // Ссылка на панель рекордов

    void Start()
    {
        mainMenuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Разблокировка курсора
        Cursor.visible = true;
    }

    public void LoadLevel(int levelIndex)
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single); // Загружаем сцену по индексу
    }

    public void ExitGame()
    {
        audioSource.PlayOneShot(clickSound);
        Application.Quit(); // Закрываем приложение
    }

    public void ShowMainMenu()
    {
        audioSource.PlayOneShot(clickSound);
        mainMenuPanel.SetActive(true);
        levelsPanel.SetActive(false);
        highScoresPanel.SetActive(false);
    }

    public void ShowLevelsPanel()
    {
        audioSource.PlayOneShot(clickSound);
        levelsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        highScoresPanel.SetActive(false);
    }

    public void ShowHighScoresPanel()
    {
        audioSource.PlayOneShot(clickSound);
        mainMenuPanel.SetActive(false);
        highScoresPanel.SetActive(true);
        levelsPanel.SetActive(false);
    }
}
