
using UnityEngine;
using System.IO;

//C:\Users\utku2\AppData\LocalLow\DefaultCompany\Teknofest-24

public class JSonManagerRocket : MonoBehaviour
{
    public RocketData _rocketData;
    public GameObject _rocket;

    private void Awake()
    {
        LoadRocketData();
    }

    #region Save&Load

    private void LoadRocketData()
    {
        if (File.Exists(Application.persistentDataPath + "/RocketData.json"))
        {
            Load();
        }
    }



    [ContextMenu("Save")]
    public void Save()
    {
        _rocketData = new RocketData(_rocket.transform.position, _rocket.transform.rotation);
        string saveJson = JsonUtility.ToJson(_rocketData, true);
        File.WriteAllText(Application.persistentDataPath + "/RocketData.json", saveJson);
    }

    public void Load()
    {
        string loadJson = File.ReadAllText(Application.persistentDataPath + "/RocketData.json");
        _rocketData = JsonUtility.FromJson<RocketData>(loadJson);

  
        _rocket.transform.position = _rocketData._lastRocketPos;
        _rocket.transform.rotation = Quaternion.Euler(_rocketData._lastRocketRot); 

        Debug.Log("Veriler Yüklendi");
    }


    #endregion
}