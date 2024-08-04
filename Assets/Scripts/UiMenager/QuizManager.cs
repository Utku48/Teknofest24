using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuestionListData questionListData;
    public GameObject[] options;
    public int currentQuestionID;
    public Lvl1ScoreController scoreController;

    public TextMeshProUGUI QuesionTxt;
    public GameObject _answeredAllQPanel;
    public GameObject repeatButton;
    public int sayac;
    public int QlistCount;

    private void Start()
    {
        questionListData.LoadQuestionsFromJson();
        QuestionAnswerList = questionListData.QuestionAnswerList;
        QlistCount = QuestionAnswerList.Count;
        generateQuestion();
        sayac = QlistCount;
    }

    private void Update()
    {

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

        questionListData.QuestionAnswerList = QuestionAnswerList;
        questionListData.SaveQuestionsToJson();
    }

    public void generateQuestion()
    {
        sayac--;


        if (sayac == 0)
        {
            _answeredAllQPanel.SetActive(true);

        }
        else
        {
            questionListData.QuestionAnswerList = QuestionAnswerList;
            questionListData.SaveQuestionsToJson();

        }



        if (QuestionAnswerList.Count == 0)
        {
            repeatButton.SetActive(false);
            return;
        }

        QuesionTxt.text = QuestionAnswerList[currentQuestionID].Question;
        SetAnswer();
    }

    public void OnSaveButtonClicked()
    {
        questionListData.SaveQuestionsToJson();
    }

    public void OnLoadButtonClicked()
    {
        questionListData.LoadQuestionsFromJson();
        QuestionAnswerList = questionListData.QuestionAnswerList;
        QlistCount = QuestionAnswerList.Count;
    }

    public List<QuestionsAndAnswers> QuestionAnswerList;
}
