using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }


    public void MainSceneStart()
    {
        StartCoroutine(ClickStartButton(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator ClickStartButton(int levelIndex)
    {

        transition.SetTrigger("Start");


        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
