using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float timeValue = 300;
    public TextMeshProUGUI timerText;

    public PlayerController player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            timeValue = 0;
            player.Die();
        }

        DisplayTime(timeValue);

        if (player.playerDead)
        {
            timeValue = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
