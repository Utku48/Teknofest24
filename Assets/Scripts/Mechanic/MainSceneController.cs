using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject parentPanel;


    public Animator transition
;
    void Start()
    {

    }


    void Update()
    {

    }

    #region MainSceneButtonController
    public void MainSceneStart()
    {

        StartCoroutine(ClickStartButton(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ParentButton()
    {
        if (!parentPanel.activeInHierarchy)
            parentPanel.SetActive(true);
    }

    public void ParentPanelClose()
    {
        if (parentPanel.activeInHierarchy)
        {
            parentPanel.SetActive(false);
        }
    }
    IEnumerator ClickStartButton(int levelIndex)
    {

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.25f);

        SceneManager.LoadScene(levelIndex);
    }



    #endregion
}
