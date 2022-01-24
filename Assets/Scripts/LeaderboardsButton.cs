using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardsButton : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip hoverSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
}
