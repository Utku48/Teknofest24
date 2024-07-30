using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacters : MonoBehaviour
{
    StarManager _starManager;

    public List<GameObject> _characters = new List<GameObject>();


    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;

    [SerializeField] private GameObject _pricePanel;
    [SerializeField] private TextMeshProUGUI _priceText;

    [SerializeField] private GameObject _buyButton;
    [SerializeField] private ParticleSystem _confetti;


    [SerializeField] private Animator alienAnim;
    [SerializeField] private Animator foxAnim;
    [SerializeField] private Animator astourantAnim;


    public int a;

    private void Start()
    {
        a = 0;

    }

    private void Update()
    {
        if (a >= 2)
        {

            _pricePanel.gameObject.SetActive(true);
            _priceText.text = (a + 1).ToString();
        }
        else _pricePanel.gameObject.SetActive(false);


    }

    public void RightButtonClick()
    {
        a++;


        if (a >= 2)
        {
            _buyButton.transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
        }

        _leftButton.gameObject.SetActive(a > 0);
        _rightButton.gameObject.SetActive(a < 4);


        foreach (var character in _characters)
        {
            character.transform.DOMove(new Vector3((character.transform.position.x - 5), character.transform.position.y, character.transform.position.z), 2f);
        }

        _rightButton.gameObject.SetActive(false);
        _leftButton.gameObject.SetActive(false);

        StartCoroutine(ButtonOnOff());
    }

    public void LeftButtonClick()
    {
        a--;

        if (a < 2)
        {
            _buyButton.transform.DOScale(Vector3.zero, .7f);
        }

        foreach (var character in _characters)
        {
            character.transform.DOMove(new Vector3((character.transform.position.x + 5), character.transform.position.y, character.transform.position.z), 2f);
        }
        _rightButton.gameObject.SetActive(false);
        _leftButton.gameObject.SetActive(false);

        StartCoroutine(ButtonOnOff());

    }


    public void BuyButton()
    {
        if (StarManager.Instance.star > 0 && (StarManager.Instance.star - (a + 1) >= 0))
        {
            StarManager.Instance.star -= (a + 1);
            StarManager.Instance.jSonManagerStar.Save();
            _confetti.Play();
        }
        if (a == 2)
        {
            //foxAnim.SetBool("choose", true);
        }
        if (a == 3)
        {
            //alienAnim.SetBool("choose", true);
        }
        if (a == 4)
        {
            astourantAnim.SetBool("choose", true);
        }


    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(2);
    }
    IEnumerator ButtonOnOff()
    {
        yield return new WaitForSeconds(2f);


        if (a <= 3)
        {
            _rightButton.gameObject.SetActive(true);

        }

        if (a >= 1)
        {

            _leftButton.gameObject.SetActive(true);
        }

    }
}

