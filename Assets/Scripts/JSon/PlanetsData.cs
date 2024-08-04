using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlanetsData
{
    public int wonStarCount = 0;
    public int trueCount = 0;

    public PlanetsData(int wonStarCount, int trueCount)
    {
        this.wonStarCount = wonStarCount;
        this.trueCount = trueCount;
    }


}