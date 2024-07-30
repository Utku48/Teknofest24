using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Lvl1ScoreController : MonoBehaviour
{

    public TextMeshProUGUI earnedText;
    public TextMeshProUGUI answeredAllQText;
    public JSonMangerPlanets jSonMangerPlanets;
    [SerializeField] private GameObject _riddlePanel;

    public int score;
    string sahneAdi;

    public int earned;

    public int trueCount = 0;

    private void Start()
    {

        score = jSonMangerPlanets._planetsData.wonStarCount;
        //jSonMangerPlanets.LoadPlanetsData();
        sahneAdi = SceneManager.GetActiveScene().name;
        //score = JSonMangerPlanets.dataBaseScore;

        Debug.Log("DBScore: " + score);

    }




    public void increaseScore()
    {
        if (trueCount % 2 == 0)
        {
            score += 1;
        }
        jSonMangerPlanets.Save(score, sahneAdi, earned);
    }


    private void Update()
    {
        earnedText.text = "" + score;
        answeredAllQText.text = ("Tüm soruları cevapladın. Bu seviyede kazanılan yıldız sayısı: " + score + "");
    }

}





