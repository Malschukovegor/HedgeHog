using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Синглтон для доступа из других скриптов

    public TextMeshProUGUI coinCounterText; // Текстовое поле для счетчика
    public int totalCoins; // Общее количество монет на уровне
    public int collectedCoins; // Количество собранных монет
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Инициализируем синглтон
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат
        }
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length; // Находим все монеты на уровне
        UpdateCoinCounter();
    }

    public void CollectCoin(int value)
    {
        collectedCoins += value;
        UpdateCoinCounter();

        if (collectedCoins >= totalCoins)
        {
            Debug.Log("Все монеты собраны!");
            // Здесь можно добавить логику для завершения уровня
        }
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = "COINS: " + collectedCoins + "/" + totalCoins;
    }
}

