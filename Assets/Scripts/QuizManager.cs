using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// public class QuizManager : MonoBehaviour
// {
//     public List<QuestionAndAnswers> QnA; // for manual adds, we won't need to worry about it i think 
//     public GameObject[] options; // UI buttons
//     // public int currentQuestion;
//     public TMP_Text QuestionTxt; // question text

//     private Dictionary<string, int> categoryScores = new Dictionary<string, int>(); // scores for each category
//     public QuestionAndAnswersData questionData; // reference to QuestionsAndAnswersData object

//     private int currentQuestionIndex = 0; // track current question
//     private int currentStage = 1; // track current stage (start at stage 1)
//     private List<QuestionAndAnswers> stageQuestions; // questions for the current stage


//     private void Start() {
//         QnA = questionData.QnA; // fills it out with answers
//         generateQuestion();
//     }

//     void setAnswers() {
//         for (int i=0; i<options.Length; i++) { 
//             if (i < QnA[currentQuestion].Answers.Length) { // Check if there are enough answers
//                 options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
//                 options[i].GetComponent<AnswerScript>().category = QnA[currentQuestion].Categories[i]; // Set the associated category
//                 options[i].SetActive(true); // Make sure the button is active
//             } else {
//                 options[i].SetActive(false); // Hide any unused options
//             }

//             options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
//             options[i].GetComponent<AnswerScript>().category = QnA[currentQuestion].Categories[i];
//         }
//     }

//     void generateQuestion() {
//         if (QnA.Count > 0) {
//             currentQuestion = Random.Range(0, QnA.Count); // Select a random question from the list
//             QuestionTxt.text = QnA[currentQuestion].Question; // Update the question text
//             setAnswers(); // Update the buttons with new answers and categories
//         } else {
//             Debug.Log("Out of Questions");
//         }
//     }

//     public void collectCategory(string category) { 
//         if (categoryScores.ContainsKey(category)) {
//             categoryScores[category]++;
//         } else {
//             categoryScores[category] = 1;
//         }
//         Debug.Log($"Category {category} score: {categoryScores[category]}");
//     }
// }

public class QuizManager : MonoBehaviour
{
    public QuestionAndAnswersData questionData; // Reference to the ScriptableObject
    public GameObject[] options; // UI Buttons
    public TMP_Text QuestionTxt; // Question Text

    private int currentStage = 0; // Track the current stage
    private int currentQuestionInStage = 0; // Track the question within the stage

    private Dictionary<string, int> categoryScores = new Dictionary<string, int>(); // Keep track of category scores

    private void Start() {
        generateStage(); // Start by generating the first stage
    }

    void generateStage() {
        if (currentStage < questionData.stages.Count) {
            currentQuestionInStage = 0; // Start at the first question of the new stage
            generateQuestion();
        } else {
            Debug.Log("All stages completed.");
            // Handle the end of quiz or results display
        }
    }

    void generateQuestion() {
        Stage currentStageData = questionData.stages[currentStage]; // Get the current stage
        if (currentQuestionInStage < currentStageData.questionsInStage.Count) {
            QuestionAndAnswers currentQnA = currentStageData.questionsInStage[currentQuestionInStage]; // Get the current question
            QuestionTxt.text = currentQnA.Question; // Update question text

            setAnswers(currentQnA); // Update buttons with answers
        } else {
            // Move to next stage when all questions in this stage are completed
            currentStage++;
            generateStage();
        }
    }

    void setAnswers(QuestionAndAnswers currentQnA) {
        for (int i = 0; i < options.Length; i++) {
            if (i < currentQnA.Answers.Length) {
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = currentQnA.Answers[i];
                options[i].GetComponent<AnswerScript>().category = currentQnA.Categories[i];
                options[i].SetActive(true); // Activate the button
            } else {
                options[i].SetActive(false); // Deactivate unused buttons
            }
        }
    }

    public void collectCategory(string category) {
        if (categoryScores.ContainsKey(category)) {
            categoryScores[category]++;
        } else {
            categoryScores[category] = 1;
        }

        Debug.Log($"Category {category} score: {categoryScores[category]}");

        // Move to the next question in the stage after selecting an answer
        currentQuestionInStage++;
        generateQuestion(); // Generate the next question
    }
}
