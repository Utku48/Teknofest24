using UnityEngine;


public class Planets : MonoBehaviour
{

    [SerializeField] public PlanetsEnum item;

    public enum PlanetsEnum
    {
        Venus,
        Mars,
        Neptune,
        Uranus,
        Pluton,
        Saturn,
        Moon,
        Earth,
        Merkur
    }

    public PlanetsEnum Planet()
    {
        return item;
    }

}

