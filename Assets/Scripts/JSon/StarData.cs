using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class StarData
{
    public int savedStarCount;

    public StarData()
    {

    }

    public StarData(int starCount)
    {
        this.savedStarCount = starCount;

    }
}
