using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Faces;

public class Lvl2Manager : MonoBehaviour
{
    public List<GameObject> faces = new List<GameObject>();


    [SerializeField] private int star;
    [SerializeField] private int trueCount;

    [SerializeField] private GameObject activeFace;
    [SerializeField] private GameObject _finalPanel;

    [SerializeField] private TextMeshProUGUI starCount;
    [SerializeField] private TextMeshProUGUI finalText;

    [SerializeField] private JsonManagerLvl2 jsonManager;

    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;


    void Start()
    {
        if (jsonManager == null)
        {
            Debug.LogError("JsonManagerLvl2 reference is missing.");
            return;
        }

        jsonManager.LoadLevel2Data();
        star = jsonManager.level2Data.Lvl2Star;
        trueCount = jsonManager.level2Data.trueCount;

        for (int i = 1; i < faces.Count; i++)
        {
            float targetY = faces[i].transform.position.y + (i * 2f);
            faces[i].transform.DOMove(
                new Vector3(faces[i].transform.position.x, targetY, faces[i].transform.position.z), 2f);
        }


        if (faces.Count == 0)
            return;
        activeFace = faces[0].gameObject;
    }

    void Update()
    {
        starCount.text = star.ToString();
        finalText.text = "Tüm duygulara cevap verdin\r\nTebrikler \r\n\r\nBu seviyeden kazandığın yıldız sayısı: " + star.ToString();

        if (faces.Count <= 0)
        {
            _finalPanel.SetActive(true);
        }

    }

    public void MoveButton(FaceState targetFaceState, float xDirection)
    {
        if (faces.Count == 0)
            return;
        activeFace = faces[0].gameObject;


        activeFace.transform.DOMove(
            new Vector3(activeFace.transform.position.x,
                        activeFace.transform.position.y,
                        activeFace.transform.position.z - 7.5f),
            0.7f)
        .OnComplete(() =>
        {
            activeFace.transform.DOMove(
                new Vector3(activeFace.transform.position.x + xDirection,
                            activeFace.transform.position.y,
                            activeFace.transform.position.z),
                0.15f)
            .OnComplete(() =>
            {
                if (faces.Count > 0 && faces[0].GetComponent<Faces>()?.face == targetFaceState)
                {
                    Debug.Log($"{targetFaceState} yönüne doğru gidildi");
                    trueCount++;
                    UpdateStarBasedOnTrueCount();

                    jsonManager.level2Data.Lvl2Star = star;
                    jsonManager.level2Data.trueCount = trueCount;
                    jsonManager.SaveLevel2Data();
                }
                else
                {
                    Debug.Log("Yanlış Yön");
                }

                if (faces.Count > 0)
                {
                    faces.RemoveAt(0);
                }
            });
        });
    }



    public void RightButton()
    {
        MoveButton(FaceState.right, 10f);
        StartCoroutine(BlockPressButtons());

    }

    public void LeftButton()
    {
        MoveButton(FaceState.left, -10f);
        StartCoroutine(BlockPressButtons());

    }



    private void UpdateStarBasedOnTrueCount()
    {
        if (trueCount == 1 && star == 0)
        {
            star += 1;
            //buraya her geldiğinde datadaki yıldıza 1 ekle
        }
        else if (trueCount == 3 && star == 1)
        {
            star += 1;
        }
        else if (trueCount == 5 && star == 2)
        {
            star += 1;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoPlanetScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }


    IEnumerator BlockPressButtons()
    {
        _rightButton.gameObject.GetComponent<Button>().enabled = false;
        _leftButton.gameObject.GetComponent<Button>().enabled = false;

        yield return new WaitForSeconds(2f);

        _rightButton.gameObject.GetComponent<Button>().enabled = true;
        _leftButton.gameObject.GetComponent<Button>().enabled = true;

    }
}

