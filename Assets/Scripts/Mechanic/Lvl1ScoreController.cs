using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;



public class Lvl1ScoreController : MonoBehaviour
{

    public TextMeshProUGUI earnedText;
    public TextMeshProUGUI answeredAllQText;
    public JSonMangerPlanets jSonMangerPlanets;
    [SerializeField] private GameObject _riddlePanel;

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

            score = _planetsData.wonStarCount;
            trueCount = _planetsData.trueCount;
        }

        //jSonMangerPlanets.LoadPlanetsData();
        sahneAdi = SceneManager.GetActiveScene().name;
        //score = JSonMangerPlanets.dataBaseScore;

        Debug.Log("DBScore: " + score);

    }




    public void increaseScore()
    {
        if (trueCount == 1 && score == 0)
        {
            score += 1;
        }
        if (trueCount == 2 && score == 1)
        {
            score += 1;
        }
        if (trueCount == 5 && score == 2)
        {
            score += 1;
        }
        jSonMangerPlanets.Save(score, sahneAdi, trueCount);
    }


    private void Update()
    {
        earnedText.text = "" + score;
        answeredAllQText.text = ("Tüm soruları cevapladın. Bu seviyede kazanılan yıldız sayısı: " + score + "");
    }

}





