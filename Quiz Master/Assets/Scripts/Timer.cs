using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltimeToCompleteQuestion = 30f;
    [SerializeField] float fltimeToShowCorrectAnswer = 10f;

    public bool bolloadNextQuestion;
    public bool bolisAnsweringQuestion = false;
    public float flfillFraction;


    float timerValue;
    void Update()
    {
        UpdateTimer();  
    }


    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(bolisAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                flfillFraction = timerValue / fltimeToCompleteQuestion;           
            }

            else
            {
                bolisAnsweringQuestion = false;
                timerValue = fltimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                flfillFraction = timerValue / fltimeToCompleteQuestion;
            }    

            else
            {
                bolisAnsweringQuestion = true;
                timerValue = fltimeToCompleteQuestion;
                bolloadNextQuestion = true;
            }
        }


        Debug.Log(bolisAnsweringQuestion + ":" + timerValue + " = " + flfillFraction);
    }


}
