using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionSceneManager : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene(2);
    }
}
