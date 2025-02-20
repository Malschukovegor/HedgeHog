using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject buttons;
    public GameObject joystics;
    public AudioClip pauseToggleSound;
    public AudioSource audioSource;
    void Awake()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void PauseGame()
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 0.0f;
        buttons.SetActive(false);
        joystics.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 1.0f;
        buttons.SetActive(true);
        joystics.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single); // Для кнопки Main Menu
    }
    public void RestartLevel()
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
