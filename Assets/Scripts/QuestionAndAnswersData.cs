using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionAndAnswers Data", menuName = "Quiz/QuestionAndAnswers Data")]
// "QuestionAndAnswers Data" is a List of Stage objects. 
// Each Stage object is a list of QuestionAndAnswers objects in that stage.
// Each QuestionAndAnswers object has the string Question, string[] Answers, string[] categories, and int stageNumber 

public class QuestionAndAnswersData : ScriptableObject
{
    public List<Stage> stages; // List of stages, each containing questions
}

