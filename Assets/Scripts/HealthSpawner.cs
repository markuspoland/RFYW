using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthBox;
    void Start()
    {
        InvokeRepeating("SpawnHealth", Random.Range(5, 20), Random.Range(8, 20));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnHealth()
    {
        float x = Random.Range(transform.position.x - 3, transform.position.x + 3);
        float z = Random.Range(transform.position.z - 3, transform.position.z + 3);
        Vector3 randomPos = new Vector3(x, transform.position.y, z);
        Instantiate(healthBox, randomPos, healthBox.transform.rotation);
    }
}
