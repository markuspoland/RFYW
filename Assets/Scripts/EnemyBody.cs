using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public EnemyController enemy;
    PlayerController player;
    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (player.pistolAmmo > 0)
        {
            enemy.TakeDamage(Random.Range(25, 35));
        }
        
    }
}
