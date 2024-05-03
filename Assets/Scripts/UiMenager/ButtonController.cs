using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button startButton;
    public Image startMessageImage;
    public GameObject _bedevi;
    public GameObject bedeviAskPos;



    public void OnStartButton()
    {
        startButton.gameObject.SetActive(false);
        startMessageImage.gameObject.SetActive(false);

        _bedevi.transform.DOMove(bedeviAskPos.transform.position, 2f).OnComplete(() => _bedevi.transform.DORotate(bedeviAskPos.transform.localEulerAngles, 2f));

    }
}
