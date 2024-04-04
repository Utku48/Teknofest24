using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Planets;
using static UnityEditor.Progress;

public class JSonMangerPlanets : MonoBehaviour
{


    private void Awake()
    {
        LoadPlanetsData();
    }

    #region Save&Load
    public void LoadPlanetsData()
    {
        foreach (var item in GameManager.Instance.planets)
        {
            if (File.Exists(Application.persistentDataPath + "/" + item.lvlID.ToString() + ".json"))
            {
                string loadJSOn = File.ReadAllText(Application.persistentDataPath + "/" + item.lvlID.ToString() + ".json");
                PlanetsData _planetsData = JsonUtility.FromJson<PlanetsData>(loadJSOn);

                item.isEntered = _planetsData.completed;
                item.getStar = _planetsData.wonStarCount;

            }
        }

    }

    public static void Save(int starCount, bool completed, PlanetsEnum levelId)
    {

        PlanetsData _planetsData = new PlanetsData(starCount, completed);
        string saveJSon = JsonUtility.ToJson(_planetsData, true);

        File.WriteAllText(Application.persistentDataPath + "/" + levelId.ToString() + ".json", saveJSon);
    }



    #endregion
}
