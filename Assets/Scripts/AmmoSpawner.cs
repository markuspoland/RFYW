using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoBox;
    void Start()
    {
        InvokeRepeating("SpawnAmmo", Random.Range(5, 50), Random.Range(5, 17));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAmmo()
    {
        float x = Random.Range(transform.position.x - 3, transform.position.x + 3);
        float z = Random.Range(transform.position.z - 3, transform.position.z + 3);
        Vector3 randomPos = new Vector3(x, transform.position.y, z);
        Instantiate(ammoBox, randomPos, ammoBox.transform.rotation);
    }
}
