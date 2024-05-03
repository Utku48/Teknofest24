using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Planets;
using static UnityEditor.Progress;

public class JSonMangerPlanets : MonoBehaviour
{
    public PlanetsData _planetsData;
    public static int dataBaseScore;

    private void Start()
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
                _planetsData = JsonUtility.FromJson<PlanetsData>(loadJSOn);


                item.gotStar = _planetsData.wonStarCount;
                dataBaseScore = item.gotStar;

            }
        }

    }

    public void Save(int winnedStarCount, string levelId, int earnedStar)
    {

        _planetsData = new PlanetsData(winnedStarCount, earnedStar);
        string saveJSon = JsonUtility.ToJson(_planetsData, true);

        File.WriteAllText(Application.persistentDataPath + "/" + levelId.ToString() + ".json", saveJSon);
        File.WriteAllText(Application.persistentDataPath, saveJSon);


    }



    #endregion
}