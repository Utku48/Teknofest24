using UnityEngine;
using UnityEngine.UI;


public class Planets : MonoBehaviour
{

    [SerializeField] public PlanetsEnum lvlID;

    public bool isEntered;
    public int gotStar = 0;

    public Image[] _starImages;

    //Gezegene girilip girilmediği
    public enum PlanetsEnum
    {
        Lvl1,
        Lvl2,
        Lvl3,
        Lvl4,
        Lvl5,
        Lvl6,
        Lvl7,
        Lvl8,
        Lvl9
    }

    public PlanetsEnum Planet()
    {
        return lvlID;
    }

    private void Update()
    {
        if (gotStar == 1)
        {
            _starImages[0].gameObject.SetActive(true);

            if (!isEntered) isEntered = true;



        }
        else if (gotStar == 2)
        {
            _starImages[0].gameObject.SetActive(true);
            _starImages[1].gameObject.SetActive(true);

            if (!isEntered) isEntered = true;

        }
        else if (gotStar >= 3)
        {
            _starImages[0].gameObject.SetActive(true);
            _starImages[1].gameObject.SetActive(true);
            _starImages[2].gameObject.SetActive(true);

            if (!isEntered) isEntered = true;
        }
    }

}

