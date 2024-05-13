using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;



public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuesionTxt;

    private void Start()
    {
        generateQuestion();
    }


    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }


    private void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswers == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if (QnA.Count == 0)
        {
            
            return;
        }

        currentQuestion = Random.Range(0, QnA.Count);

        QuesionTxt.text = QnA[currentQuestion].Question;
        SetAnswer();

        QnA.RemoveAt(currentQuestion);
    }


}
