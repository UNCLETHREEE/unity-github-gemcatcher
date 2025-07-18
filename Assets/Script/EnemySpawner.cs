using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 30f;
    public float enemyLifetime = 40f;

    public Transform[] spawnPoints;
    public AudioClip enemySpawnSFX;

    public float initialDelay = 5f; // ⏳ How long to wait before first spawn

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // Wait before first spawn
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            if (spawnPoints.Length == 0)
            {
                Debug.LogWarning("No spawn points assigned to EnemySpawner!");
                yield return new WaitForSeconds(spawnInterval);
                continue;
            }   

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            if (enemySpawnSFX != null)
                AudioManager.Instance.PlaySFX(enemySpawnSFX);

            Destroy(enemy, enemyLifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
