using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public int score = 0;

    public bool oneStar = false;
    public bool twoStar = false;
    public bool threeStar = false;

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene(2);



        if (score == 1 && !twoStar && !threeStar)
        {
            oneStar = true;
            StarManager.Instance.star += 1;
        }
        else if (score == 2 && !threeStar)
        {
            if (!oneStar && !twoStar)
            {
                twoStar = true;
                StarManager.Instance.star += 2;
            }
            else if (twoStar)
            {
                Debug.Log("Zaten 2 score yaptınız");
            }
            else if (oneStar && !twoStar)
            {
                twoStar = true;
                StarManager.Instance.star += 1;
            }
        }
        else if (score >= 3)
        {
            if (!oneStar && !twoStar && !threeStar)
            {
                threeStar = true;
                StarManager.Instance.star += 3;
            }
            else if (oneStar && !twoStar && !threeStar)
            {
                threeStar = true;
                StarManager.Instance.star += 2;
            }
            else if (twoStar && !threeStar)
            {
                threeStar = true;
                StarManager.Instance.star += 1;
            }
        }


        StarManager.Instance.jSonManagerStar.Save();
    }


    public void increaseCompleteLevel()
    {
        score++;
    }
}