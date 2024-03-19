using DG.Tweening;
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

    [SerializeField] private TextMeshProUGUI _priceText;

    public int a = 0;

    private void Start()
    {
        _leftButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (a >= 2)
        {
            _priceText.gameObject.SetActive(true);

            _priceText.text = a + 1 + " Star".ToString();
        }

    }

    public void RightButtonClick()
    {
        a++;
        if (a >= 4)
        {
            _rightButton.gameObject.SetActive(false);
        }
        else
        {
            _rightButton.gameObject.SetActive(true);
        }

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

        if (a <= 1)
        {
            _rightButton.gameObject.SetActive(false);
        }
        else
        {
            _rightButton.gameObject.SetActive(true);
        }


        foreach (var character in _characters)
        {
            character.transform.DOMove(new Vector3((character.transform.position.x + 5), character.transform.position.y, character.transform.position.z), 2f);
        }
        _rightButton.gameObject.SetActive(false);
        _leftButton.gameObject.SetActive(false);

        StartCoroutine(ButtonOnOff());

    }


    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
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

