using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int pistolAmmo;
    int pistolMaxAmmo = 5;
    int magazineAmmo;

    int health;

    float reloadTime = 1.5f;

    AudioSource audioSource;

    public AudioClip shootGun;
    public AudioClip emptyGun;
    public AudioClip reloadGun;

    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI healthAmount;

    public bool isReloading;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isReloading = false;
        pistolAmmo = pistolMaxAmmo;
        magazineAmmo = 20;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pistolAmmo > 0 && !isReloading)
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(0) && pistolAmmo <= 0 && !isReloading && magazineAmmo > 0)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetMouseButtonDown(0) && pistolAmmo <= 0 && magazineAmmo <= 0)
        {
            audioSource.PlayOneShot(emptyGun);
        }

        ammoCount.SetText(pistolAmmo + " / " + magazineAmmo);
        healthAmount.SetText(health.ToString());
        
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(shootGun);
        pistolAmmo--;

        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        audioSource.PlayOneShot(reloadGun);
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        pistolAmmo += pistolMaxAmmo;
        magazineAmmo -= 5; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
        }

    }
}
