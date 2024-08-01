using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject parentPanel;
    void Start()
    {

    }


    void Update()
    {

    }

    #region MainSceneButtonController
    public void MainSceneStart()
    {
        SceneManager.LoadScene(1);
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

    

    #endregion
}
