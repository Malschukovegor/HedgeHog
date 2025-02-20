using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform startPoint; // Стартовая точка
    public GameObject player;   // Объект игрока

    void Start()
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        // Устанавливаем игрока в стартовую точку
        player.transform.position = startPoint.position;
        player.transform.rotation = startPoint.rotation;
    }
}
