using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] spawners;
    public GameObject[] enemies;

    public float spawnInterval;
    public float spawnLevelInterval;
    float spawnTimer;
    float spawnLevelTimer;

    int maxSpawn = 8;
    int curTotalSpawn = 2;
    int curMinSpawn = 2;

    int maxEnemylevel;
    int curMinEnemyLevel;

    void Start()
    {
        maxEnemylevel = enemies.Length - 1;    
    }

    void Update()
    {
        if (GameManager.instance.ready) {
            spawnTimer += Time.deltaTime;
            spawnLevelTimer += Time.deltaTime;
        }

        if (spawnTimer >= spawnInterval) {
            Spawn();
        }

        if (spawnLevelTimer > spawnLevelInterval) {
            Debug.Log("Increase difficulty");
            if (curMinEnemyLevel < maxEnemylevel) {
                curMinEnemyLevel++;
            }

            if (curTotalSpawn < maxSpawn) {
                curTotalSpawn++;
                curMinSpawn++;
            }

            spawnLevelTimer = 0;
        }
    }

    void Spawn()
    {
        int spawnNum = Random.Range(curMinSpawn, curTotalSpawn);
        spawnTimer = 0;

        for (int i = 0; i < spawnNum; i++) {
            int randomSpawner = Random.Range(0, spawners.Length - 1);
            int randomEnemy = Random.Range(0, curMinEnemyLevel);

            Instantiate(enemies[randomEnemy], spawners[randomSpawner].position, Quaternion.identity);
        }
    }
}
