using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO strcurrentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int intcorrectAnswerIndex;
    bool bolhasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite sprdefaultAnswerSprite;
    [SerializeField] Sprite sprcorrectAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;


    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        timerImage.fillAmount = timer.flfillFraction;
        if (timer.bolloadNextQuestion)
        {
            bolhasAnsweredEarly = false;
            GetNextQuestion();
            timer.bolloadNextQuestion = false;
        }
        else if (!bolhasAnsweredEarly && !timer.bolisAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);

        }
    }



    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);
        bolhasAnsweredEarly = true;
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }

    void DisplayAnswer(int index)
    {

        Image imgbuttonImage;


        if (index == strcurrentQuestion.GetCorrectAnswerIndex())
        {
            questiontext.text = "Correct!";
            imgbuttonImage = answerButtons[index].GetComponent<Image>();
            imgbuttonImage.sprite = sprcorrectAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            intcorrectAnswerIndex = strcurrentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = strcurrentQuestion.GetAnswer(intcorrectAnswerIndex);
            questiontext.text = "Sorry, the correct answer was;\n" + correctAnswer;
            imgbuttonImage = answerButtons[intcorrectAnswerIndex].GetComponent<Image>();
            imgbuttonImage.sprite = sprcorrectAnswerSprite;
        }
    }
  
    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        strcurrentQuestion = questions[index];

        if(questions.Contains(strcurrentQuestion))
        {
            questions.Remove(strcurrentQuestion);
        }
    }



    void DisplayQuestion()
    {
        questiontext.text = strcurrentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = strcurrentQuestion.GetAnswer(i);
        }

    }

    void SetButtonState(bool state)
    {
        for(int i = 0;i < answerButtons.Length;i++) 
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length;i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = sprdefaultAnswerSprite;
        }
    }
}
