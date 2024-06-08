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

    private void Start()
    {
        earnedText.text = "" + jSonMangerPlanets._planetsData.earnedStar.ToString();
        //jSonMangerPlanets.LoadPlanetsData();
        sahneAdi = SceneManager.GetActiveScene().name;
        score = JSonMangerPlanets.dataBaseScore;
        earned = score;

    }




    public void increaseScore()
    {
        if (score < 3)
        {
            score++;
            CheckStar();
            jSonMangerPlanets.Save(score, sahneAdi, earned);
        }
        else Debug.Log("Score 3'ü geçti");


    }

    void CheckStar()
    {
        if (score == 1)
        {
            StarManager.Instance.star += (score - earned);
            earned = 1;
            Debug.Log("KAZANIYORELEMAN");
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
    private void Update()
    {
        earnedText.text = "" + earned;
        answeredAllQText.text = ("Tüm soruları cevapladın. Bu seviyede kazanılan yıldız sayısı: " + earned + "");
    }

}





