using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;

    private float min;
    private float sec;


    // Start is called before the first frame update
    void Start()
    {
        SetTimer(1, 30); 
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    private void SetTimer(float min, float sec)
    {
        this.min = min;
        this.sec = sec;
    }

    private void CountTime()
    {
        if(min >= 0)
        {
            sec -= 1 * Time.deltaTime;

            if (sec <= 0)
            {
                min -= 1;
                sec = 59;
            }
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

}
