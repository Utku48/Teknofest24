using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManagerLvl2 : MonoBehaviour
{
    [System.Serializable]
    public class Level2Data
    {
        public int Lvl2Star;
       

        public Level2Data(int lvl2Star)
        {
            Lvl2Star = lvl2Star;
     
        }
    }

    public Level2Data level2Data;
   

    private void Start()
    {
        LoadLevel2Data();
    }



    #region Save&Load

    public void SaveLevel2Data()
    {
        if (level2Data == null)
        {
            Debug.LogError("Level2Data is not set.");
            return;
        }

        string saveJson = JsonUtility.ToJson(level2Data, true);
        File.WriteAllText(Application.persistentDataPath + "/Level2Data.json", saveJson);
        Debug.Log("Level2Data saved to " + Application.persistentDataPath + "/Level2Data.json");
    }

    public void LoadLevel2Data()
    {
        string filePath = Application.persistentDataPath + "/Level2Data.json";

        if (File.Exists(filePath))
        {
            string loadJson = File.ReadAllText(filePath);
            level2Data = JsonUtility.FromJson<Level2Data>(loadJson);
            Debug.Log("Level2Data loaded from " + filePath);
        }
        else
        {
            Debug.LogWarning("No Level2Data file found at " + filePath);
        }
    }

    #endregion
}
