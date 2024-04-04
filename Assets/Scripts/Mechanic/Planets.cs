using UnityEngine;


public class Planets : MonoBehaviour
{

    [SerializeField] public PlanetsEnum lvlID;
    public bool isEntered = false;
    public int getStar = 0;
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

}

