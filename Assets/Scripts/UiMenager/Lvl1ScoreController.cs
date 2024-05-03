using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Lvl1ScoreController : MonoBehaviour
{


    public JSonMangerPlanets jSonMangerPlanets;

    public int score;
    string sahneAdi;

    public int earned;

    private void Start()
    {

        jSonMangerPlanets.LoadPlanetsData();
        sahneAdi = SceneManager.GetActiveScene().name;
        score = JSonMangerPlanets.dataBaseScore;
        earned = score;

    }

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene(2);
        StarManager.Instance.jSonManagerStar.Save();
    }


    public void increaseScore()
    {
        score++;
        CheckStar();
        jSonMangerPlanets.Save(score, sahneAdi, earned); ;

    }

    void CheckStar()
    {
        if (score == 1)
        {
            StarManager.Instance.star += (score - earned);
            earned = 1;
        }
        else if (score == 2)
        {
            StarManager.Instance.star += (score - earned);
            earned = 2;
        }
        else if (score == 3)
        {
            StarManager.Instance.star += (score - earned);
            earned = 3;
        }

        else
        {
            Debug.Log("Alacagını Almıs");
        }
    }
}





