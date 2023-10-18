using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltimeToCompleteQuestion = 30f;
    [SerializeField] float fltimeToShowCorrectAnswer = 10f;
    
    public bool bolisAnsweringQuestion = false;
    
    float timerValue;
    void Update()
    {
        UpdateTimer();  
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(bolisAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                bolisAnsweringQuestion = false;
                timerValue = fltimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue <= 0) 
            {
                bolisAnsweringQuestion = true;
                timerValue = fltimeToCompleteQuestion;
            }
        }


        Debug.Log(timerValue);
    }


}
