using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;



public class Lvl1ScoreController : MonoBehaviour
{

    public TextMeshProUGUI earnedText;
    public TextMeshProUGUI answeredAllQText;
    public JSonMangerPlanets jSonMangerPlanets;



    public int score;

    string sahneAdi;


    public int trueCount = 0;

    private void Start()
    {
        PlanetsData _planetsData = null;

        if (File.Exists(Application.persistentDataPath + "/" + "Lvl1.json"))
        {
            string loadJSOn = File.ReadAllText(Application.persistentDataPath + "/" + "Lvl1.json");
            _planetsData = JsonUtility.FromJson<PlanetsData>(loadJSOn);

            score = StarManager.Instance.starData.savedStarCount;

        }

        //jSonMangerPlanets.LoadPlanetsData();
        sahneAdi = SceneManager.GetActiveScene().name;
        //score = JSonMangerPlanets.dataBaseScore;

        Debug.Log("DBScore: " + score);

    }




    public void increaseScore()
    {
        score++;
        StarManager.Instance.starData.savedStarCount++;
        StarManager.Instance.Save();
        jSonMangerPlanets.Save(score, sahneAdi);

    }


    private void Update()
    {
        earnedText.text = "" + score;
        answeredAllQText.text = ("Tüm soruları cevapladın. Bu seviyede kazanılan yıldız sayısı: " + score + "");
    }

}





