
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoxTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            if (other.gameObject.name == "Alien")
            {
                Debug.Log("ccccc");
                StarManager.Instance.DecreaseStar(8);
            }
        
            Debug.Log(other.gameObject.name);
        }
    }
}
