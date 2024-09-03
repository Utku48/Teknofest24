using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionSceneManager : MonoBehaviour
{
    [SerializeField] List<GameObject> questions = new List<GameObject>();
    [SerializeField] private GameObject _continueButton;

    void Start()
    {
        // Başlangıçta yapılacak işlemler varsa buraya yazabilirsin
    }

    void Update()
    {
        foreach (GameObject question in questions)
        {
            // Question içindeki tüm ToggleButton'ları al
            Toggle[] toggles = question.GetComponentsInChildren<Toggle>();
            bool isAnyToggleOn = false;

            foreach (Toggle toggle in toggles)
            {
                if (toggle.isOn)
                {
                    isAnyToggleOn = true;
                    break;
                }
            }

            // Eğer hiçbir Toggle aktif değilse, hata mesajı ver
            if (!isAnyToggleOn)
            {
                Debug.Log("Hepsi Cevaplanmadı");
                _continueButton.GetComponent<Button>().enabled = false;
                _continueButton.GetComponent<Animator>().enabled = false;
                return;
            }
        }

        // Eğer buraya kadar geldiyse, tüm questions içinde en az bir aktif Toggle var
        Debug.Log("Tüm Questions Cevaplandı");

        _continueButton.GetComponent<Button>().enabled = true;
        _continueButton.GetComponent<Animator>().enabled = true;
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene(2);
    }
}
