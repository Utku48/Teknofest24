using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlanetsData
{
    public int wonStarCount = 0;
    public bool completed = false;

    public PlanetsData(int wonStarCount, bool completed)
    {
        this.wonStarCount = wonStarCount;
        this.completed = completed;
    }
}
