using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float timer;
    int health;
    public enum EnemySide { Right, Left }

    public EnemySide enemySide;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        transform.position = enemySpawner.transform.position;
        timer = 1f;
        health = 100;
    }
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 2.5f * Time.deltaTime;

        if (timer > 0f)
        {
            if (enemySide == EnemySide.Left)
            {
                transform.Translate(-Vector3.right * 3f * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * 3f * Time.deltaTime);
            }
        }
    }

    private void OnDisable()
    {
        
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            enemySpawner.isSpawned = false;
            gameObject.SetActive(false);
            
        }
    }

}
