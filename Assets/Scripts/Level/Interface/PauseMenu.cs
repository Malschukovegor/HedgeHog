using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    public AudioClip pauseToggleSound;
    public AudioSource audioSource;
    private bool isPaused = false;
    void Awake()
    {
        pauseMenuPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        pauseButton.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        audioSource.PlayOneShot(pauseToggleSound);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        pauseButton.SetActive(true);
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
