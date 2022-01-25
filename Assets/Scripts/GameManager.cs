using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;


public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(GameManager).Name;
                    _instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }

    public int score;
    public string playerName;

    public string testPlayer1 = "Mietek";
    public string testPlayer2 = "Zenek";
    public int testScore1 = 350;
    public int testScore2 = 1500;

    int id = 1367;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        InitializeLootLocker();
    }

    void InitializeLootLocker()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });

    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player name set!");
            }
            else
            {
                Debug.Log("Player name not set!");
            }
        });
    }

    public void SubmitScore()
    {

        LootLockerSDKManager.SubmitScore(playerName, score, id, (response) =>
        {
            if (response.success)
            {

            }
            else
            {
                Debug.Log("SCORE NOT SUBMITTED :(");
            }
        });


    }

}
