using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleSound : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на AudioSource
    public Button soundToggleButton; // Ссылка на кнопку
    public TextMeshProUGUI soundButtonText; // Текстовое поле кнопки

    private bool isSoundOn = true; // Флаг для отслеживания состояния звука

    void Start()
    {
        // Обновляем текст кнопки в зависимости от состояния звука
        UpdateButtonText();
    }

    public void TogglingSound()
    {
        // Переключаем состояние звука
        isSoundOn = !isSoundOn;

        // Включаем или выключаем звук
        audioSource.mute = !isSoundOn;

        // Обновляем текст кнопки
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        // Меняем текст кнопки в зависимости от состояния звука
        if (isSoundOn)
        {
            soundButtonText.text = "MUSIC / ON";
        }
        else
        {
            soundButtonText.text = "MUSIC / OFF";
        }
    }
    void OnDestroy()
    {
        soundToggleButton.onClick.RemoveListener(TogglingSound);
    }
}