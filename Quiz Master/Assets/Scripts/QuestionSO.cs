using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string strquestion = "Enter new question here";
    [SerializeField] string[] stranswers = new string[4];
    [SerializeField] int intCorrectAnswerIndex;
    public string GetQuestion()
    {
        return strquestion;
    }
    public string GetAnswer(int index)
    {
        return stranswers[index];
    }
    public int GetCorrectAnserIndex()
    {
        return intCorrectAnswerIndex;
    }


}
