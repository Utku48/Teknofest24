using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void CharacterSelectionScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void IncreaseButtonWithButton()
    {
        StarManager.Instance.IncreaseStar();
    }

}


