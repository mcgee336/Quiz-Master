using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO strquestion;
    [SerializeField] GameObject[] answerButtons;
     int intcorrectAnswerIndex;
    [SerializeField] Sprite sprdefaultAnswerSprite;
    [SerializeField] Sprite sprcorrectAnswerSprite;

    void Start()
    {
        questiontext.text = strquestion.GetQuestion();  

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = strquestion.GetAnswer(i);
        }


    }
    public void OnAnswerSelected(int index)
    {
        Image imgbuttonImage;


        if (index == strquestion.GetCorrectAnswerIndex()) 
        {
            questiontext.text = "Correct!";
            imgbuttonImage = answerButtons[index].GetComponent<Image>();
            imgbuttonImage.sprite = sprcorrectAnswerSprite;
        } 
        else
        {
            intcorrectAnswerIndex = strquestion.GetCorrectAnswerIndex();
            string correctAnswer = strquestion.GetAnswer(intcorrectAnswerIndex);
            questiontext.text = "Sorry, the correct answer was;\n" + correctAnswer;
            imgbuttonImage = answerButtons[intcorrectAnswerIndex].GetComponent<Image>();
            imgbuttonImage.sprite = sprcorrectAnswerSprite;
        }
    }
  
}
