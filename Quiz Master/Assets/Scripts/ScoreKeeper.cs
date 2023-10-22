using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int intcorrectAnswers = 0;
    int intquestionsSeen = 0;


    public int GetCorrectAnswers()
    { 
        return intcorrectAnswers;
    }
    public void IncrementCorrectAnswers()
    { 
        intcorrectAnswers++;
    }

    public int GetQuestionsSeen()
    {
        return intquestionsSeen;
    }

    public void IncrementQuestionsSeen()
    {
        intquestionsSeen++;
    }

    public int CalculateScore()
    { 
        return Mathf.RoundToInt(intcorrectAnswers / (float)intquestionsSeen * 100);
    }



}
