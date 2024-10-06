using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA; // for manual adds, we won't need to worry about it 
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    private Dictionary<string, int> categoryScores = new Dictionary<string, int>(); // Dictionary to keep track of scores for each category
    public QuestionAndAnswersData questionData; // Reference to QuestionsAndAnswersData object

    private void Start() {
        QnA = questionData.QnA; // fills it out with answers
        generateQuestion();
    }

    void setAnswers() {
        for (int i=0; i<options.Length; i++) { 
            if (i < QnA[currentQuestion].Answers.Length) { // Check if there are enough answers
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
                options[i].GetComponent<AnswerScript>().category = QnA[currentQuestion].Categories[i]; // Set the associated category
                options[i].SetActive(true); // Make sure the button is active
            } else {
                options[i].SetActive(false); // Hide any unused options
            }

            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<AnswerScript>().category = QnA[currentQuestion].Categories[i];
        }
    }

    void generateQuestion() {
        if (QnA.Count > 0) {
            currentQuestion = Random.Range(0, QnA.Count); // Select a random question from the list
            QuestionTxt.text = QnA[currentQuestion].Question; // Update the question text
            setAnswers(); // Update the buttons with new answers and categories
        } else {
            Debug.Log("Out of Questions");
        }
    }

    public void collectCategory(string category) { 
        if (categoryScores.ContainsKey(category)) {
            categoryScores[category]++;
        } else {
            categoryScores[category] = 1;
        }
        Debug.Log($"Category {category} score: {categoryScores[category]}");
    }
}