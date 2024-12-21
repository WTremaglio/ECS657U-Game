using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;
    
    private int waveNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() {
        waveNumber++;
        Debug.Log("Wave Incomming!");
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new  WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
