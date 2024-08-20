using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacters : MonoBehaviour
{
    StarManager _starManager;

    public List<GameObject> _characters = new List<GameObject>();

    [SerializeField] private JSonCharacterManager _characterManager;



    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;

    [SerializeField] private GameObject _pricePanel;
    [SerializeField] private TextMeshProUGUI _priceText;

    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private ParticleSystem _confetti;

    [SerializeField] private GameObject _door;



    [SerializeField] private Transform ImageParent;

    [SerializeField] private GameObject _stageCh;

    public int a;

    private void Start()
    {
        a = 0;

    }

    private void Update()
    {
        _pricePanel.SetActive(a >= 2);
        _priceText.text = (a + 1).ToString();



    }

    public void RightButtonClick()
    {
        a++;
        _stageCh = _characters[a].gameObject;


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

        SetCharacterImage();

    }

    public void LeftButtonClick()
    {
        a--;
        _stageCh = _characters[a].gameObject;

        if (a < 2)
        {
            _buyButton.transform.DOScale(Vector3.zero, 0.7f);
        }

        MoveCharacters(5);
        ToggleButtons(false);
        StartCoroutine(ButtonOnOff());

        SetCharacterImage();

    }



    public void BuyButton()
    {
        if (_stageCh.GetComponent<CharactersType>().activeCharacter) return;

        int cost = a + 1;
        if (StarManager.Instance.starData.savedStarCount >= cost)
        {
            StarManager.Instance.starData.savedStarCount -= cost;
            StarManager.Instance.Save();
            _confetti.Play();
            _stageCh.GetComponent<CharactersType>().activeCharacter = true;
            _stageCh.GetComponent<Animator>()?.SetBool("choose", true);
        }

        SetCharacterImage();
        _characterManager.SaveCharacterData();

    }

    public void SettingButton()
    {
        _settingPanel.SetActive(true);
        foreach (var item in _characters)
        {
            item.SetActive(false);
        }
    }

    public void CloseButton()
    {

        _settingPanel.SetActive(false);
        foreach (var item in _characters)
        {
            item.SetActive(true);
        }
    }
    public void ContinueButton()
    {
        _door.SetActive(true);
        StartCoroutine(LoadScene());
    }
    private IEnumerator ButtonOnOff()
    {
        yield return new WaitForSeconds(2f);
        _rightButton.gameObject.SetActive(a <= 3);
        _leftButton.gameObject.SetActive(a >= 1);
    }

    private void MoveCharacters(float xOffset)
    {
        foreach (var character in _characters)
        {
            character.transform.DOMove(new Vector3(character.transform.position.x + xOffset, character.transform.position.y, character.transform.position.z), 2f);
        }
    }

    private void ToggleButtons(bool state)
    {
        _rightButton.gameObject.SetActive(state);
        _leftButton.gameObject.SetActive(state);
    }

    private void SetCharacterImage()
    {
        if (_stageCh.GetComponent<CharactersType>().activeCharacter)
        {

            foreach (Transform item in ImageParent)
            {
                item.gameObject.SetActive(false);
            }
            ImageParent.GetChild(a).gameObject.SetActive(true);
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(2);
    }
}
