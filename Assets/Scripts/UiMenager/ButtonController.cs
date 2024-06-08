using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    #region UiPanels
    public GameObject _riddlePanel;
    public Button startButton;
    public Button continueButton;
    public Image startMessageImage;

    public GameObject _answeredAllQ;
    #endregion


    public GameObject _bedevi;
    public GameObject _bedeviGoPos;
    public GameObject[] QuestionNanswers;

    private Animator _bedeviAnim;


    private void Start()
    {
        _bedeviAnim = _bedevi.GetComponent<Animator>();
    }

    public void OnContinueButton()
    {
        _bedeviAnim.SetBool("isWalking", true);
        startButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        startMessageImage.gameObject.SetActive(false);

        _bedevi.transform.DOMove(_bedeviGoPos.transform.position, 2f).OnComplete(() => _bedeviAnim.SetBool("isWalking", false));



    }

    public void OnStartButton()
    {
        _riddlePanel.SetActive(true);
        StartCoroutine(ActivateQuestionNanswers());
        _bedevi.SetActive(false);
    }

    IEnumerator ActivateQuestionNanswers()
    {
        for (int i = 0; i < QuestionNanswers.Length; i++)
        {
            QuestionNanswers[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void ReloadScene()
    {
        Scene activescene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activescene.name);
        this.gameObject.SetActive(false);
    }
    public void LoadLevelSelectionScreen()
    {
        SceneManager.LoadScene(2);
        StarManager.Instance.jSonManagerStar.Save();
    }

    private void Update()
    {

    }
}
