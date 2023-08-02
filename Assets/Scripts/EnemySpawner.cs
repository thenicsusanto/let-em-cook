using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> enemySpawnPoint;
    public List<GameObject> enemyPrefabList;

    [SerializeField] private float countDown;
    public Wave[] waves;
    private int currentWaveIndex;

    [SerializeField] private bool waveSpawned = false;

    float placeHolder;

    private void Start()
    {
        placeHolder = 0;
    }

    private void Update()
    {
        placeHolder -= Time.deltaTime;

        if (!waveSpawned && placeHolder <= 0)
        {
            StartCoroutine(SpawnWave());
            waveSpawned = true;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].numEnemies; i++)
        {
            int spawnIndex = Random.Range(0, enemySpawnPoint.Count);
            int enemyToSpawn = 0;

            //change this to spawn customer prefab with different customer order
            GameObject newCustomer = Instantiate(enemyPrefabList[enemyToSpawn], enemySpawnPoint[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(waves[currentWaveIndex].timingBetweenEnemies);
        }
        placeHolder = countDown;
    }

    [System.Serializable]
    public class Wave
    {
        public int numEnemies;
        public float timingBetweenEnemies;
    }
}
