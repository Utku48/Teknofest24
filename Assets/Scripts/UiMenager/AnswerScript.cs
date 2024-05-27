using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Lvl1ScoreController lvl1ScoreController;

    public GameObject _clickedButton;

    private void Start()
    {
        quizManager.currentQuestionID = 0;

    }

    public void Answer()
    {

        if (isCorrect)
        {

            Debug.Log("CorrectAnswer");

            lvl1ScoreController.increaseScore();

            StartCoroutine(greenButton());

        }
        else
        {
            Debug.Log("WrongAnswer");

            if (quizManager.currentQuestionID < (quizManager.QuestionAnswerList.Count) - 1)
            {
                quizManager.currentQuestionID++;
            }
            else
            {
                quizManager.currentQuestionID = 0;
            }
            quizManager.generateQuestion();
        }


    }


    IEnumerator greenButton()
    {
        Debug.Log("corotouniess");
        _clickedButton.GetComponent<Image>().color = Color.green;
        Destroy(this.gameObject);
        yield return new WaitForSeconds(.75f);

        quizManager.QuestionAnswerList.RemoveAt(quizManager.currentQuestionID);
        quizManager.generateQuestion();


    }
}