using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int value = 1; // Значение монеты (по умолчанию 1)
    public GameObject platform;
    public GameObject coinCollectEffect;
    private float rotationSpeed = 150;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

        if (platform != null)
        {
            Vector3 offset = new Vector3(0, 1.5f, 0);
            transform.position = platform.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(coinCollectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CoinManager.Instance.CollectCoin(value); // Уведомляем CoinManager
        }    
    }
}
