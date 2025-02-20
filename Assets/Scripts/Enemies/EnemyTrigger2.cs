using UnityEngine;

public class EnemyTrigger2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool enemiesSpawned = false;
    public Vector3[] spawnPoints;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned)
        {
            SpawnEnemyPrefabs();
            enemiesSpawned = true;
        }
    }

    void SpawnEnemyPrefabs()
    {
        foreach (Vector3 point in spawnPoints)
        {
            Instantiate(enemyPrefab, point, Quaternion.identity);
        }
    }
}
