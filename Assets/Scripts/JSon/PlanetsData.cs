using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlanetsData
{
    public int wonStarCount = 0;
    public int earnedStar = 0;

    public PlanetsData(int wonStarCount, int earnedStar)
    {
        this.wonStarCount = wonStarCount;
        this.earnedStar = earnedStar;
    }


}