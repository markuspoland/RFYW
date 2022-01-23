using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHandler : MonoBehaviour
{
    public AudioClip bloodSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(bloodSound);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
