using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TileCounter tileCounter;
    [SerializeField] private TMP_Text timerTxt;

    private float min;
    private float sec;
    private bool isGameOver;

    void Start()
    {
        isGameOver = false;
        SetTimer(1, 30); 
    }

    void Update()
    {
        if (!isGameOver)
        {
            CountTime();
        }
    }

    private void SetTimer(float min, float sec)
    {
        this.min = min;
        this.sec = sec;
    }

    private void CountTime()
    {
        if (min >= 0)
        {
            sec -= 1 * Time.deltaTime;

            if (sec <= 0)
            {
                min -= 1;
                sec = 59;
            }
        }

        if (min < 0)
        {
            min = 0;
            sec = 0;
            isGameOver = true;
            GameOver();
            //Time.timeScale = 0f;
        }

        if (sec >= 9.5f)
        {
            timerTxt.SetText("0" + min + ":" + Mathf.Round(sec));
        }
        else
        {
            timerTxt.SetText("0" + min + ":0" + Mathf.Round(sec));
        }
    }

    private void GameOver()
    {
        List<TileCounter.PlayerScore> rankings = tileCounter.GetRankings();
        DisplayWinner(rankings);
    }

    private void DisplayWinner(List<TileCounter.PlayerScore> rankings)
    {
        if (rankings.Count > 0)
        {
            Debug.Log("Winner: " + rankings[0].PlayerName + " with " + rankings[0].Score + " tiles");
        }
    }
}
