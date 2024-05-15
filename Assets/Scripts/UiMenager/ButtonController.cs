using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject _riddlePanel;
    public Button startButton;
    public Image startMessageImage;
    public GameObject _bedevi;
    public GameObject bedeviAskPos;

    public GameObject[] QuestionNanswers;

    public void OnStartButton()
    {
        startButton.gameObject.SetActive(false);
        startMessageImage.gameObject.SetActive(false);

        _bedevi.transform.DOMove(bedeviAskPos.transform.position, 2f)
            .OnComplete(() =>
            {
                _bedevi.transform.DORotate(bedeviAskPos.transform.localEulerAngles, 2f)
                    .OnComplete(() =>
                    {
                        _riddlePanel.SetActive(true);
                        StartCoroutine(ActivateQuestionNanswers());
                    });
            });
    }

    IEnumerator ActivateQuestionNanswers()
    {
        for (int i = 0; i < QuestionNanswers.Length; i++)
        {
            QuestionNanswers[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f); 
        }
    }


}
