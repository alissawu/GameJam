using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionTxt;

    private void Start() {
        generateQuestion();
    }

    public void correct() {
        QnA.RemoveAt(currentQuestion);
        generateQuestion(); // getting correct answer generates next question
    }

    void setAnswers() {
        for (int i=0; i<options.Length; i++) { // go through buttons one by one and assign answer to it
            options[i].GetComponent<AnswerScript>().isCorrect = false; // all buttons falst at start, only correct gets set to true
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1) {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion() {
        // currentQuestion = Random.Range(0, QnA.Count); // change to be whichever question is on 
        currentQuestion = 0;
        QuestionTxt.text = QnA[currentQuestion].Question;
        setAnswers();

    }
}