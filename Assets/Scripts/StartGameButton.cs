using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGameButton : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip startSound;

    public GameObject startPanel;

    public TMP_InputField inputField;

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
        if (gameObject.CompareTag("StartPanel"))
        {
            audioSource.PlayOneShot(startSound);
            startPanel.SetActive(true);
        }

        if (gameObject.CompareTag("StartGame"))
        {
            GameManager.Instance.playerName = inputField.text;
            Debug.Log(GameManager.Instance.playerName);
            audioSource.PlayOneShot(startSound);
            SceneManager.LoadScene("Level1");
        }

        if (gameObject.CompareTag("MenuButton"))
        {
            MenuClick();
        }

        if (gameObject.CompareTag("ExitButton"))
        {
            ExitGame();
        }
        
    }

    public void MenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
