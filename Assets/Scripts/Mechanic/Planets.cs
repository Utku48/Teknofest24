using UnityEngine;
using UnityEngine.UI;


public class Planets : MonoBehaviour
{

    [SerializeField] public PlanetsEnum lvlID;
    public GameObject _rocketUpPos;
    public GameObject _rocketFirstPos;

    public bool isEntered;
    public int gotStar;

    public Image[] _starImages;
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

    void Start()
    {

    }
    private void Update()
    {

    }

}

