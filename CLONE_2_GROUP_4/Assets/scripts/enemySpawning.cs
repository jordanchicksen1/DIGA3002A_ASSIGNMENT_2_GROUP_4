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

    void Start()
    {
        listSize = enemyQueue.Count;
        index = 0;
    }
    
    void Update()
    {
        if (enemiesKilled % killGoal == 0 && enemiesKilled > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = Instantiate(enemyQueue[index], transform.position, Quaternion.identity);
                index++;
            }
        }
    }
}
