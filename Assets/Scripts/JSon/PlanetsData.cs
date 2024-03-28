using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlanetsData
{
    public List<GameObject> JPlanets = new List<GameObject>();

    public GameObject isActive;
  
    public PlanetsData()
    {


    }
    public PlanetsData(GameObject isActive)
    {
        this.isActive = isActive;

    }


}
