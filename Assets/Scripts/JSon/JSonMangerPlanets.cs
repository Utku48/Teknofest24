using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSonMangerPlanets : MonoBehaviour
{
    PlanetsData _planetsData;

    private void Awake()
    {
        LoadPlanetsData();
    }

    #region Save&Load
    private void LoadPlanetsData()
    {
        if (File.Exists(Application.persistentDataPath + "/Planets.json"))
        {
            Load();
        }
    }

    public void Save()
    {
        _planetsData = new PlanetsData();
        string saveJSon = JsonUtility.ToJson(_planetsData, true);
    }

    public void Load()
    {
        string loadJSOn = File.ReadAllText(Application.persistentDataPath + "/Planets.json");
        _planetsData = JsonUtility.FromJson<PlanetsData>(loadJSOn);
    }

    #endregion
}
