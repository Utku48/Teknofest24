using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class RocketData
{
    public Vector3 _lastRocketPos;
    public Vector3 _lastRocketRot;
  
    public RocketData()
    {

    }

    public RocketData(Vector3 lastRocketPos, Quaternion lastRocketRot)
    {
        this._lastRocketPos = lastRocketPos;
        this._lastRocketRot = lastRocketRot.eulerAngles;
  
    }
}
