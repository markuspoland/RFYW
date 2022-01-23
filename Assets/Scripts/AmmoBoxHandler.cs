using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxHandler : MonoBehaviour
{
    PlayerController player;
    float speed = 3f;
    void Start()
    {
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
            player.AddAmmo(20);
            Destroy(gameObject);
        }
        
    }
}
