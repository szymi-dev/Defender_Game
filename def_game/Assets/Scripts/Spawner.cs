using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public EnemyDMG enemy;
    public Transform[] spawnPoints;
    

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingAlive;
    int enemiesRemainingToSpawn;
    float nextTimeSpawn;


    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        if(enemiesRemainingToSpawn > 0 && Time.time > nextTimeSpawn)
        {
            enemiesRemainingToSpawn--;
            nextTimeSpawn = Time.time + currentWave.timeBtwSpawn;

            EnemyDMG spawnedEnemy = Instantiate(enemy, spawnPoints[rand].position, Quaternion.identity) as EnemyDMG;
            spawnedEnemy.transform.SetParent(transform);
            spawnedEnemy.OnDeath += OnDeathEnemy;
        }
    }

    void OnDeathEnemy()
    {
        enemiesRemainingAlive--;

        if(enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        if(currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;

            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }



    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBtwSpawn;   
    }

    




}
