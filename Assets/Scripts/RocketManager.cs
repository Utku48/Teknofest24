using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketManager : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Planets>())
        {
            string _levelName = other.gameObject.GetComponent<Planets>().item.ToString();
            Debug.Log(_levelName);
            StartCoroutine(LoadScene(_levelName));
        }
    }


    IEnumerator LoadScene(string levelName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName + "Scene");

    }

}
