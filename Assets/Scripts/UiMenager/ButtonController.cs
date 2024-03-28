
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene(2);

        StarManager.Instance.star += 1;
        StarManager.Instance.jSonManagerStar.Save();
    }



}


