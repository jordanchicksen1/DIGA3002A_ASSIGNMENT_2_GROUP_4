using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    public List<GameObject> enemyQueue = new List<GameObject>();
    public List <Transform> spawnPoints = new List<Transform>();
    private int listSizeE;
    private int listSizeS;
    private int index;
    public int enemiesKilled = 0;
    public int killGoal = 3;
    public int enemyCount = 3;

    private int lastSpawnKillCount = 0;

    void Start()
    {
        listSizeE = enemyQueue.Count;
        listSizeS = spawnPoints.Count;
        index = 0;
        SpawnBatch();
    }

    void Update()
    {
        if (enemiesKilled >= lastSpawnKillCount + killGoal)
        {
            SpawnBatch();
            lastSpawnKillCount = enemiesKilled;
        }
    }

    void SpawnBatch()
    {
        //Temporary list to use number representation of spawns that are still available
        List<int> availableSpawns = new List<int>();
        for (int i = 0; i < listSizeS; i++)
        {
            availableSpawns.Add(i);
        }

        for (int i = 0; i < enemyCount; i++)
        {
            if (index >= listSizeE || availableSpawns.Count == 0)
                return;
            
            int randIndex = Random.Range(0, availableSpawns.Count);
            int spawnPointIndex = availableSpawns[randIndex];

            Instantiate(enemyQueue[index], spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            index++;
            availableSpawns.RemoveAt(randIndex); //Remove a spawnpoint if it was used
        }
    }

}

