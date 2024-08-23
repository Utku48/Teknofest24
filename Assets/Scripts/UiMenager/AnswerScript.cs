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

    [SerializeField] private Sprite _correctImage;
    [SerializeField] private Sprite _wrongImage;
    [SerializeField] private Sprite _defaultImage;

    private void Start()
    {
        quizManager.currentQuestionID = 0;

    }

    public void Answer()
    {

        if (isCorrect)
        {

            Debug.Log("CorrectAnswer");

            quizManager.QuestionAnswerList.RemoveAt(quizManager.currentQuestionID);
            StartCoroutine(Answered());

            lvl1ScoreController.trueCount++;
            lvl1ScoreController.increaseScore();


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
            StartCoroutine(Answered());

        }


    }


    IEnumerator Answered()
    {
        if (isCorrect)
        {
            _clickedButton.gameObject.GetComponent<Image>().sprite = _correctImage;
        }
        else
        {
            _clickedButton.gameObject.GetComponent<Image>().sprite = _wrongImage;
        }
        yield return new WaitForSeconds(3f);

        _clickedButton.gameObject.GetComponent<Image>().sprite = _defaultImage;
        quizManager.generateQuestion();
    }

}