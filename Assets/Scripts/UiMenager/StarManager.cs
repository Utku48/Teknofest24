using UnityEngine;
using TMPro;


public class StarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _starCounter;
    public int star;

    public JSonManagerStar jSonManagerStar;


    public static StarManager Instance { get; private set; }

    public int decreaseValue;
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
    private void Update()
    {
        _starCounter.text = star.ToString();
    }


    public void IncreaseStar()
    {
        star += 1;
        jSonManagerStar.Save();
    }

    public void DecreaseStar() //butona basıp Alien gelince burası çalışyor. CharacterBoxTrigger içerisine bak
    {
        if (star <= 0 || star < decreaseValue)
        {
          
            Debug.Log("Star sıfırdan küçük veya Star sayınız az");
        }
        else
        {


            star -= decreaseValue;
            jSonManagerStar.Save();

        }
    }


}
