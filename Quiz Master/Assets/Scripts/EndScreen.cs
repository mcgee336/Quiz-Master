using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtfinalScoreText;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        txtfinalScoreText.text = "Congratulations!\nYou got a score of " + 
            scoreKeeper.CalculateScore() + "%";
    }
}
