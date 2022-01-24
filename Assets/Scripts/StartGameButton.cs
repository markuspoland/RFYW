using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip startSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(startSound);
        SceneManager.LoadScene("Level1");
    }
}
