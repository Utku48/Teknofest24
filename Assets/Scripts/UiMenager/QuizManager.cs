using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.SceneManagement;



public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QuestionAnswerList;
    public GameObject[] options;
    public int currentQuestionID;
    public Lvl1ScoreController scoreController;

    public TextMeshProUGUI QuesionTxt;
    public GameObject _answeredAllQPanel;

    public int sayac;
    public int QlistCount;
    private void Start()
    {
        QlistCount = QuestionAnswerList.Count;
        generateQuestion();
        sayac--;
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
        if (sayac < (QlistCount - 1))
        {
            sayac++;
        }
        else
        {
            _answeredAllQPanel.SetActive(true);
        }


        if (QuestionAnswerList.Count == 0)
        {
            return;
        }


        QuesionTxt.text = QuestionAnswerList[currentQuestionID].Question;
        SetAnswer();

    }



    //10 tane soru getir. 7 tane bilirse 3 yıldız ve ve gönder
}
