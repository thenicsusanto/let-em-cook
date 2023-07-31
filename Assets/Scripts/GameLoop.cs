using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLoop : MonoBehaviour
{
    //runtime variables
    bool enemySpawn;


    //runtime variables
    public int roundNum;

    public int customersHelped;
    public int customersFailed;

    int minute;

    int enemiesSpawned;


    //game logic
    int[] numOfCustomers = { 5, 7, 10, 14, 18 };

    int[] customerPatienceTimer = { 30, 25, 20, 15, 15 };

    int[] numOfEnemies = { 30, 33, 37, 48, 50 };

    //optimize later
    int[][] enemy1 = { new int[] { 7, 10 }, new int[] { 5, 7 }, new int[] { 2, 5 } };
    int[][] enemy2 = { new int[] { 6, 9 }, new int[] { 4, 6 }, new int[] { 2, 3 } };
    int[][] enemy3 = { new int[] { 5, 8 }, new int[] { 3, 5 }, new int[] { 1, 3 } };
    int[][] enemy4 = { new int[] { 4, 7 }, new int[] { 1, 3 }, new int[] { 1, 3 } };
    int[][] enemy5 = { new int[] { 3, 6 }, new int[] { 1, 3 }, new int[] { 1, 3 } };


    List<int[][]> rounds;

    //game objects
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        customersHelped = 0;
        customersFailed = 0;
        enemiesSpawned = 0;

        rounds.Add(enemy1);
        rounds.Add(enemy2);
        rounds.Add(enemy3);
        rounds.Add(enemy4);
        rounds.Add(enemy5);

        minute = 0;

        StartCoroutine(nextEnemySpawn());

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 120)
            minute = 2;
        else if ((int)Time.time > 60)
            minute = 1;
        else
            minute = 0;

        if (enemySpawn && enemiesSpawned < numOfEnemies[roundNum])
        {
            //instantiate later
            StartCoroutine(nextEnemySpawn());
        }

        if (customersHelped == numOfCustomers[roundNum])
        {
            //reload screen, but change roundNum to ++
        }

        if (customersFailed <= 3)
        {
            //load failed screen
        }

        if (player.GetComponent<Movement>().health <= 0)
        {
            //load failed screen
        }


    }

    IEnumerator nextEnemySpawn()
    {
        yield return new WaitForSeconds(Random.Range(rounds[roundNum][minute][0], rounds[roundNum][roundNum][1] + 1));
        enemySpawn = true;
    }
}
