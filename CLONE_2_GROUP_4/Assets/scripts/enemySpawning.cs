using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    public List<GameObject> enemyQueue = new List<GameObject>();
    private int listSize;
    private int index;
    public int enemiesKilled = 0;
    public int killGoal = 3;
    public int enemyCount = 3;

    private int lastSpawnKillCount = 0;

    void Start()
    {
        listSize = enemyQueue.Count;
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
        for (int i = 0; i < enemyCount; i++)
        {
            if (index >= listSize)
                return;

            Instantiate(enemyQueue[index], transform.position, Quaternion.identity);
            index++;
        }
    }
}

