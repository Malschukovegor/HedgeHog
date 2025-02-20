using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance; // Синглтон для доступа к Canvas

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем Canvas
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат
        }
    }
}
