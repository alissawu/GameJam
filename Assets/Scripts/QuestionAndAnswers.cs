[System.Serializable]

public class QuestionAndAnswers
{
    public string Question;
    public string[] Answers;
    public string[] Categories; // Holds categories for each answer
    public int stageNumber; // The stage this question belongs to
    public string StoryText; // text before (going with) a question
}



