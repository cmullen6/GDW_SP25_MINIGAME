using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array to hold different enemies
    public Transform[] spawnPoints;    // Array of spawn points for enemies
    public float spawnInterval = 3f;

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Randomly pick an enemy prefab from the array
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Randomly pick a spawn point from the array
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the enemy at the selected spawn point
        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}

