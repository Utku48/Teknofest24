using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCharacters : MonoBehaviour
{
    [SerializeField] private GameObject _boy;
    [SerializeField] private GameObject _girl;

    [SerializeField] private Transform _boyWait;
    [SerializeField] private Transform _boyFront;

    [SerializeField] private Transform _girlWait;
    [SerializeField] private Transform _girlFront;

    private bool isButtonPressed = false;

    public void OnButtonClick()
    {
        isButtonPressed = !isButtonPressed;

        if (isButtonPressed)
        {
            MoveCharacters(_boyWait.transform.position, _girlFront.transform.position);
        }
        else
        {
            MoveCharacters(_boyFront.transform.position, _girlWait.transform.position);
        }
    }

    private void MoveCharacters(Vector3 boyPosition, Vector3 girlPosition)
    {
        _boy.transform.DOMove(boyPosition, 2f);
        _girl.transform.DOMove(girlPosition, 2f);
    }
}

