using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    void Start()
    {
        InvokeRepeating("SpawnBomb", Random.Range(5, 20), Random.Range(8, 20));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBomb()
    {
        float x = Random.Range(transform.position.x - 3, transform.position.x + 3);
        float z = Random.Range(transform.position.z - 3, transform.position.z + 3);
        Vector3 randomPos = new Vector3(x, transform.position.y, z);
        Instantiate(bomb, randomPos, bomb.transform.rotation);
    }
}
