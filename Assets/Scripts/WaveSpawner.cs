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
    [SerializeField] private GameObject customerPrefab;

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
        for(int i=0; i < waves[currentWaveIndex].customerOrders.Length; i++)
        {
            //change this to spawn customer prefab with different customer order
            GameObject newCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
            newCustomer.gameObject.GetComponent<Customer>().order = waves[currentWaveIndex].customerOrders[i];
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextCustomer);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public Order[] customerOrders;
        public float timeToNextCustomer;
    }
}
