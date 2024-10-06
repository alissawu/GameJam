using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public QuestionAndAnswersData questionData; // Reference to the ScriptableObject
    public GameObject[] options; // UI Buttons
    public TMP_Text QuestionTxt; // Question Text

    private int currentStage = 0; // Track the current stage
    private int currentQuestionInStage = 0; // Track the question within the stage

    private Dictionary<string, int> categoryScores = new Dictionary<string, int>(); // Keep track of category scores

    public PanelImageManager panelImageManager;

    private void Start() {
        panelImageManager.SetPanelImage(currentStage); // Set the initial image
        generateStage(); // Start by generating the first stage
    }

    void generateStage() {
        if (currentStage < questionData.stages.Count) {
            currentQuestionInStage = 0; // Start at the first question of the new stage
            panelImageManager.SetPanelImage(currentStage); // Update image when stage changes
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
