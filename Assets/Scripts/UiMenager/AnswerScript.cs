using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Lvl1ScoreController lvl1ScoreController;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("CorrectAanswer");
            quizManager.generateQuestion();
            lvl1ScoreController.increaseScore();
        }
        else
        {
            Debug.Log("WrongAnswer");
            quizManager.generateQuestion();
        }


    }

}

