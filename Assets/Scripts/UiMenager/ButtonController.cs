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
    public GameObject _backPanel;

    public GameObject _turningPanel;

    public GameObject _starUi;
    public GameObject _planetUi;

    public Button startButton;
    public Button continueButton;
    public Image startMessageImage;
    public Image continueMessageImage;

    public float rotationSpeed;

    #endregion


    public GameObject astourant;
    public GameObject _astGoPos;
    public GameObject[] QuestionNanswers;

    public Animator _astAnim;


    private void Start()
    {
        _astAnim = astourant.GetComponent<Animator>();

    }


    private void Update()
    {

        _turningPanel.transform.DORotate(new Vector3(0, 0, 360), 360 / rotationSpeed, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear) // Sabit hızda döndür
                 .SetLoops(-1, LoopType.Incremental);
    }
    public void OnContinueButton()
    {
        _astAnim.SetBool("isWalking", true);
        startButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        startMessageImage.gameObject.SetActive(false);





        astourant.transform.DOMove(_astGoPos.transform.position, 2f).OnComplete(() =>
        {
            _astAnim.SetBool("isWalking", false);
            astourant.transform.DORotateQuaternion(_astGoPos.transform.localRotation, 2f);
            continueMessageImage.gameObject.SetActive(true);
        });



    }

    public void OnStartButton()
    {
        _riddlePanel.SetActive(true);
        StartCoroutine(ActivateQuestionNanswers());
        astourant.SetActive(false);
        continueMessageImage.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        _backPanel.gameObject.SetActive(true);
        _starUi.SetActive(false);
        _planetUi.SetActive(false);
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
        StarManager.Instance.Save();
    }



}
