using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionAndAnswers Data", menuName = "Quiz/QuestionAndAnswers Data")]
public class QuestionAndAnswersData : ScriptableObject
{
    public List<QuestionAndAnswers> QnA; // List to hold QuestionAndAnswers objects
}
