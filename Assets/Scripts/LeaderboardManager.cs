using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    int id = 1367;
    int maxScores = 11;
    public TextMeshProUGUI[] ranks;
    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] playerScores;

    void Start()
    {
        LootLockerSDKManager.StartSession(GameManager.Instance.testPlayer1, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });

        SetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(id, maxScores, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Error retrieving leaderboard");

                return;
            }

            LootLockerLeaderboardMember[] scores = response.items;

            for (int i = 0; i < scores.Length; i++)
            {
                ranks[i].text = scores[i].rank.ToString();
                names[i].text = scores[i].player.name;
                playerScores[i].text = scores[i].score.ToString();
            }

            if (scores.Length < maxScores)
            {
                for (int i = scores.Length; i < maxScores; i++)
                {
                    ranks[i].text = (i + 1).ToString();
                    names[i].text = "";
                    playerScores[i].text = 0.ToString();
                }
            }

        });
    }

    public void SubmitScore()
    {

        
        LootLockerSDKManager.SubmitScore(GameManager.Instance.testPlayer1, GameManager.Instance.testScore1, id, (response) =>
        {
            if (response.success)
            {
                
            }else
            {
                Debug.Log("SCORE NOT SUBMITTED :(");
            }
        });

        ShowScores();
    }

    public void SetName()
    {
        LootLockerSDKManager.SetPlayerName(GameManager.Instance.testPlayer1, (response) =>
        {
            if (response.success)
            {

            } else
            {
                Debug.Log("Player name not set!");
            }
        });
    }
}
