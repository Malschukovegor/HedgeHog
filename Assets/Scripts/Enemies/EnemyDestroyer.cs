using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private GameObject[] enemies;
    public float rotationSpeed = 200.0f;
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject platform;
    public GameObject colorEffect;
    void Update()
    {
        if (platform != null)
        {
            Vector3 offset = new Vector3 (0, 2, 0);
            transform.position = platform.transform.position + offset;
        }
        
        pipe1.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        pipe2.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(colorEffect, transform.position, Quaternion.identity);

            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Уничтожаем все объекты с тегом "Enemy"
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            // Очищаем массив (необязательно, но полезно)
            enemies = new GameObject[0];
        }
    }
}
