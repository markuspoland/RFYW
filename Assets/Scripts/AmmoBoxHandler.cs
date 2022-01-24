using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxHandler : MonoBehaviour
{
    PlayerController player;
    float speed = 3f;
    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerController>();
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
            scoreManager.AddScore(ScoreInfo.ammoPts);
            player.AddAmmo(20);
            Destroy(gameObject);
        }
        
    }
}
