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

    public AudioClip ammoPickup;
    public AudioClip healthPickup;

    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI healthAmount;

    public GameObject reloadingTextObject;
    public GameObject dmgScreen;
    public GameObject gameOver;
    public GameObject restart;
    public CrosshairScript crosshair;

    public bool isReloading;
    public bool playerDead;
    void Start()
    {
        playerDead = false;
        dmgScreen.SetActive(false);
        reloadingTextObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        isReloading = false;
        pistolAmmo = pistolMaxAmmo;
        magazineAmmo = 20;
        health = 100;
        crosshair = FindObjectOfType<CrosshairScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && pistolAmmo > 0 && !isReloading && !playerDead)
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
        reloadingTextObject.SetActive(true);
        isReloading = true;
        audioSource.PlayOneShot(reloadGun);
        yield return new WaitForSeconds(reloadTime);
        reloadingTextObject.SetActive(false);
        isReloading = false;
        pistolAmmo += pistolMaxAmmo;
        magazineAmmo -= 5; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(GetHit());

        if (health <= 0)
        {
            health = 0;
            Die();
        }

    }

    void Die()
    {
        playerDead = true;
        health = 0;
        gameOver.SetActive(true);
        restart.SetActive(true);
        crosshair.isVisible = true;
        crosshair.gameObject.SetActive(false);
        dmgScreen.SetActive(false);
    }

    public void AddAmmo(int ammoToAdd)
    {
        magazineAmmo += ammoToAdd;
        audioSource.PlayOneShot(ammoPickup);

        if (magazineAmmo > 150)
        {
            magazineAmmo = 150;
        }
    }

    public void AddHealth(int healthAmount)
    {
        health += healthAmount;
        audioSource.PlayOneShot(healthPickup);

        if (health > 100)
        {
            health = 100;
        }
    }

    IEnumerator GetHit()
    {
        dmgScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        dmgScreen.SetActive(false);
    }
}
