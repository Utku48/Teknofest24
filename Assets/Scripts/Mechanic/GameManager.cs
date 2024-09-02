using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<Planets> planets = new List<Planets>();

    [SerializeField] private Transform ImageParent;

    int a;

    [SerializeField] private GameObject _doorOpen;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

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
        UpdatePlanets();
        a = StarManager.Instance.starData.a;

        SetCharacterImage();

    }

    public void CharacterSelectionScreen()
    {
        SceneManager.LoadScene(2);
    }
    private void Update()
    {
    }
    public void UpdatePlanets()
    {
        GetComponent<JSonMangerPlanets>().LoadPlanetsData();

        for (int i = 1; i < planets.Count; i++)
        {
            if (planets[i - 1].isEntered)
            {
                planets[i].GetComponent<SphereCollider>().enabled = true;
            }
        }
    }


    private void SetCharacterImage()
    {


        foreach (Transform item in ImageParent)
        {
            item.gameObject.SetActive(false);
        }
        ImageParent.GetChild(a).gameObject.SetActive(true);
    }

   
}