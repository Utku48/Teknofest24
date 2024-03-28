
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoxTrigger : MonoBehaviour
{
    public CharactersType _characterType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            _characterType = other.gameObject.GetComponent<CharactersType>();


            StarManager.Instance.decreaseValue = _characterType.valueOfCharacter;

            Debug.Log(_characterType.valueOfCharacter);
        }
    }
}
