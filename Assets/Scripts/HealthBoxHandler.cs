using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxHandler : MonoBehaviour
{
    PlayerController player;
    float speed = 3f;
    ScoreManager scoreManager;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (!player.playerDead)
        {
            scoreManager.AddScore(ScoreInfo.healthPts);
            player.AddHealth(Random.Range(10, 30));
            Destroy(gameObject);
        }
        
    }
}
