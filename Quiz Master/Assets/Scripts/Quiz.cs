using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO strquestion;
    void Start()
    {
        questiontext.text = strquestion.GetQuestion();
    }

  
}
