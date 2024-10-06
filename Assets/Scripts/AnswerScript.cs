using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public QuizManager quizManager;
    public string category; // for categories

    public void Answer() {
        Debug.Log($"Selected Category: {category}"); 
        quizManager.collectCategory(category); // Call QuizManager to collect categories
    }

}
