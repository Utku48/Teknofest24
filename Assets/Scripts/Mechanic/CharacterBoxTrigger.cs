
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoxTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            Debug.Log("karakterGeldi");
            Debug.Log(other.gameObject.name);
        }
    }
}
