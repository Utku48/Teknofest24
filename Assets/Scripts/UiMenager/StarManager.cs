﻿using UnityEngine;
using TMPro;
using System.IO;


public class StarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _starCounter;

    public StarData starData;


    public static StarManager Instance { get; private set; }

    // If there is an instance, and it's not me, delete myself.
    private void Awake()
    {
        LoadStarData();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
    }
    private void Update()
    {
        _starCounter.text = starData.savedStarCount.ToString();
    }

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
        starData = new StarData(starData.savedStarCount, starData.a);
        string saveJson = JsonUtility.ToJson(starData, true);

        File.WriteAllText(Application.persistentDataPath + "/CoinData.json", saveJson);


    }

    public void Load()
    {
        string loadJSOn = File.ReadAllText(Application.persistentDataPath + "/CoinData.json");
        starData = JsonUtility.FromJson<StarData>(loadJSOn);


    }


    public static void AddStar(int amount)
    {

    }




}
