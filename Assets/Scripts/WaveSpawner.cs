using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countDown;
    public Wave[] waves;
    [SerializeField] private Transform spawnPoint;
    private int currentWaveIndex;
    [SerializeField] private bool waveSpawned = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        countDown -= Time.deltaTime;

        if (!waveSpawned && countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            waveSpawned = true;
        }
    }

    IEnumerator SpawnWave()
    {
        for(int i=0; i < waves[currentWaveIndex].customers.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].customers[i], spawnPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextCustomer);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public GameObject[] customers;
        public float timeToNextCustomer;
    }
}
