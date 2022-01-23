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

    public Material normalMaterial;
    public Material hitMaterial;

    public AudioClip enemyShoot;

    public GameObject[] bloodEffects;
    public GameObject chunkEffect;
    public Transform body;

    PlayerController player;
    AudioSource audioSource;
    private void OnEnable()
    {
        GetComponentInChildren<Renderer>().material.color = normalMaterial.color;
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
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
        StartCoroutine(GetHit());
        Vector3 mousePos = Input.mousePosition;
        Instantiate(bloodEffects[Random.Range(0, bloodEffects.Length - 1)], GetPosition(), Quaternion.identity);

        if (health <= 0)
        {
            enemySpawner.isSpawned = false;
            gameObject.SetActive(false);
            Instantiate(chunkEffect, GetPosition(), Quaternion.identity);
            
        }
    }

    public void ShootPlayer()
    {
        audioSource.PlayOneShot(enemyShoot);
        player.TakeDamage(Random.Range(5, 12));
        
        
    }

    IEnumerator GetHit()
    {
        GetComponentInChildren<Renderer>().material.color = hitMaterial.color;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<Renderer>().material.color = normalMaterial.color;
    }

    Vector3 GetPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, body.position.z + 22));
    }

}
