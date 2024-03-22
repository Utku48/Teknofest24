using UnityEngine;
using TMPro;


public class StarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _starCounter;
    public int star;

    public JSonManagerStar jSonManagerStar;

    public static StarManager Instance { get; private set; }
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

    public void DecreaseStar(int valueOfCharacter) //butona basıp Alien gelince burası çalışyor. CharacterBoxTrigger içerisine bak
    {
        if (star <= 0)
        {
            Debug.Log("star sıfırdan küçük olamaz");
        }
        else
        {
            star -= valueOfCharacter;
            jSonManagerStar.Save();
        }
    }
}
