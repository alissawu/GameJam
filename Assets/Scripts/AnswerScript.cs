using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer() {
        if (isCorrect) {
            Debug.Log("Correct Answer");
            quizManager.correct();
        } else {
            Debug.Log("Wrong Answer");
            quizManager.correct(); // just to move on
        }
    }
}
