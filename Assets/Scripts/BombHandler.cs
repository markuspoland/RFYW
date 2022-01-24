using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    PlayerController player;
    float speed = 3f;
    ScoreManager scoreManager;
    EnemyController[] enemies;
    AudioSource audioSource;

    public AudioClip bombFalling;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        
        audioSource.PlayOneShot(bombFalling);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        enemies = FindObjectsOfType<EnemyController>();
    }

    private void OnMouseDown()
    {
        if (!player.playerDead)
        {
            scoreManager.AddScore(ScoreInfo.bombPts);
            foreach (var enemy in enemies)
            {
                if (enemy)
                {
                    enemy.TakeDamage(100);
                }
                
            }

            player.Explode();
            Destroy(gameObject);
        }

    }
}
