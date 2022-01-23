using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public bool isSpawned { get; set; } = false;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", Random.Range(2, 10), Random.Range(10, 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        if (!isSpawned)
        {
            enemy.SetActive(true);
            isSpawned = true;
        }
    }
}
