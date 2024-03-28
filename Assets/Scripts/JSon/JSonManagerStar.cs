
using UnityEngine;
using System.IO;


public class JSonManagerStar : MonoBehaviour
{
    public StarData starData;


    private void Start()
    {
        LoadStarData();
    }

    #region Save&Load

    private void LoadStarData()
    {
        if (File.Exists(Application.persistentDataPath + "/CoinData.json"))
        {
            Debug.Log("loading");
            Load();
        }

    }

    public void Save()
    {
        starData = new StarData(StarManager.Instance.star);
        string saveJson = JsonUtility.ToJson(starData, true);

        File.WriteAllText(Application.persistentDataPath + "/CoinData.json", saveJson);


    }

    public void Load()
    {
        string loadJSOn = File.ReadAllText(Application.persistentDataPath + "/CoinData.json");
        starData = JsonUtility.FromJson<StarData>(loadJSOn);

        //LoadEdilen coin sayısını ata
        StarManager.Instance.star = starData.JstarCount;
    }
    #endregion



}