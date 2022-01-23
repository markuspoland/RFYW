using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
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
        if (player.pistolAmmo > 0 && !player.playerDead)
        {
            enemy.TakeDamage(Random.Range(65, 100));
        }
        
    }
}
