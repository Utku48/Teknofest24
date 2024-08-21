using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class StarData
{
    public int savedStarCount;
    public int a;


    public StarData(int starCount, int a)
    {
        this.savedStarCount = starCount;
        this.a = a;

    }

}
