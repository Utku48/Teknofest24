using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<Planets> planets = new List<Planets>();


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
    }

    public void CharacterSelectionScreen()
    {
        SceneManager.LoadScene(1);
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
}
