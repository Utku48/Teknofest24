using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor.iOS;
using UnityEngine;



public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QuestionAnswerList;
    public GameObject[] options;
    public int currentQuestionID;
    public Lvl1ScoreController scoreController;

    public TextMeshProUGUI QuesionTxt;

    private void Start()
    {
        generateQuestion();
    }

    private void Update()
    {
        print("CurrentQID: " + currentQuestionID);
    }

 


    private void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestionAnswerList[currentQuestionID].Answers[i]; //Şıklara,şıkların üzerinde yazacak olan seçenekleri atıyoruz.

            if (QuestionAnswerList[currentQuestionID].correctAnswersID == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
            }
        }
    }

    public void generateQuestion()
    {
        if (QuestionAnswerList.Count == 0)
        {

            return;
        }

        currentQuestionID = 0;

        QuesionTxt.text = QuestionAnswerList[currentQuestionID].Question;
        SetAnswer();
        QuestionAnswerList.RemoveAt(currentQuestionID);

        currentQuestionID++;
    }

    //10 tane soru getir. 7 tane bilirse 3 yıldız ve ve gönder
}
