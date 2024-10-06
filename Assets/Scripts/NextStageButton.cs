using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageButton : MonoBehaviour
{
    public QuizManager quizManager; // Reference to the QuizManager

    public void OnNextStageButtonClicked()
    {
        // Call the NextStage method from the QuizManager
        quizManager.NextStage();
    }
}
