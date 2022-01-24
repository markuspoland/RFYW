using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreCount;
    public GameObject ptsObject;
    int score;
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.SetText(score.ToString());
    }

    public void AddScore(int scoreToAdd)
    {
        StartCoroutine(ShowPoints("+" + scoreToAdd.ToString()));
        
        score += scoreToAdd;
    }

    IEnumerator ShowPoints(string text)
    {
        ptsObject.SetActive(true);
        ptsObject.GetComponent<TextMeshProUGUI>().SetText(text);
        ptsObject.GetComponent<TextMeshProUGUI>().transform.position = Input.mousePosition;
        yield return new WaitForSeconds(1f);
        ptsObject.SetActive(false);
    }
}
