using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    string buttonTag;

    string facebookUrl = "https://www.facebook.com/kingspheremetal";
    string youtubeUrl = "https://www.youtube.com/channel/UCUNVUEdzAAjAWnbCm8YDnmQ";
    string instagramUrl = "https://www.instagram.com/kingspheremetal/";
    string spotifyUrl = "https://open.spotify.com/artist/4Sye4PjGd7hLDPl0Ir16l4?si=RUrjI2FjThKRfE-AyXJMfg";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenURL()
    {
        buttonTag = gameObject.tag;

        switch (buttonTag)
        {
            case "facebook":
                Application.OpenURL(facebookUrl);
                break;
            case "youtube":
                Application.OpenURL(youtubeUrl);
                break;
            case "instagram":
                Application.OpenURL(instagramUrl);
                break;
            case "spotify":
                Application.OpenURL(spotifyUrl);
                break;
        }
    }
}
