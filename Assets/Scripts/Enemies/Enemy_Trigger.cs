using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Trigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfPrefabs;
    public bool enemySpawned = false;
    public float positionX;
    public float positionZ;
    public float positionY;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemySpawned)
        {
            SpawnEnemyPrefab();
            enemySpawned = true;
        }
    }

    void SpawnEnemyPrefab()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector3 enemyPosition = new Vector3 (positionX, positionY, positionZ);
            Instantiate(enemyPrefab, enemyPosition, enemyPrefab.transform.rotation);
        }
    }
}
