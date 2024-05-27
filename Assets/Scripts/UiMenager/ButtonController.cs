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
    public Image startMessageImage;

    public GameObject _answeredAllQ;
    #endregion


    public GameObject _bedevi;
    public GameObject[] QuestionNanswers;


   
    public void OnStartButton()
    {
        startButton.gameObject.SetActive(false);
        startMessageImage.gameObject.SetActive(false);

        _bedevi.transform.DOMove(new Vector3(_bedevi.transform.position.x, _bedevi.transform.position.y + 15f, _bedevi.transform.position.z), .25f).OnComplete(() => _bedevi.SetActive(false));
        _riddlePanel.SetActive(true);
        StartCoroutine(ActivateQuestionNanswers());


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
