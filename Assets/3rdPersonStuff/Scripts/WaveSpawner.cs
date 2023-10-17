using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Transform Player;
    public GameObject EnemyPrefab;
    public int numOfEnemies = 5;
    public float EnemyScale = 0.7f;
    public float TimeBetweenWaves = 20;
    public int enemyMax = 200;
    private float countdown = 0;


    //tracks every frame the amount of enemies that can spawn in, and are currently spawning in
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave(numOfEnemies));
            //this line makes it so over time more and more enemies spawn to increase difficulty
            numOfEnemies += (int) (Mathf.Sqrt(numOfEnemies) * EnemyScale);
            countdown = TimeBetweenWaves;
        }
    }

    //this spawns an enemy about every second
    IEnumerator SpawnWave(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    //this allows the prefab that is imnput into the wave manager to actually spawn enemies
    void SpawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Transform spawnPoint = SpawnPoints[spawnPointIndex];
        GameObject spawnedEnemy = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
        spawnedEnemy.GetComponent<MoveToDestination>().Destination = Player;
    }
}
