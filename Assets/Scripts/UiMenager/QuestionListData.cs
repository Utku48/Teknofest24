using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class QuestionsAndAnswers
{
    public string Question;
    public string[] Answers;
    public int correctAnswersID;
}

[System.Serializable]
public class QuestionsAndAnswersListWrapper
{
    public List<QuestionsAndAnswers> QuestionsAndAnswers;
}

public class QuestionListData : MonoBehaviour
{
    public List<QuestionsAndAnswers> QuestionAnswerList;

    private void Start()
    {
        LoadQuestionsFromJson();
        SaveQuestionsToJson();
    }

    public void SaveQuestionsToJson()
    {
        string json = JsonUtility.ToJson(new QuestionsAndAnswersListWrapper { QuestionsAndAnswers = QuestionAnswerList }, true);
        File.WriteAllText(Application.persistentDataPath + "/questions.json", json);
        Debug.Log("Questions saved to JSON.");
    }

    public void LoadQuestionsFromJson()
    {
        string path = Application.persistentDataPath + "/questions.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            QuestionsAndAnswersListWrapper wrapper = JsonUtility.FromJson<QuestionsAndAnswersListWrapper>(json);
            QuestionAnswerList = wrapper.QuestionsAndAnswers;
            Debug.Log("Questions loaded from JSON.");
        }
        else
        {
            Debug.Log("Questions file not found.");
        }
    }

    public void RemoveQuestion(int questionIndex)
    {
        if (questionIndex >= 0 && questionIndex < QuestionAnswerList.Count)
        {
            QuestionAnswerList.RemoveAt(questionIndex);
            SaveQuestionsToJson();
            Debug.Log("RemoveQÇalıştı");
        }
        else
        {
            Debug.LogError("Invalid question index.");
        }
    }
}
