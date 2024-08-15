using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static Faces;

public class Lvl2Manager : MonoBehaviour
{
    public List<GameObject> faces = new List<GameObject>();

    [SerializeField] private int a;
    [SerializeField] private int star;
    [SerializeField] private int trueCount;
    [SerializeField] private TextMeshProUGUI starCount;

    [SerializeField] private JsonManagerLvl2 jsonManager;
    public JSonManagerStar jSonManagerStar;

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
        a = 0;
        for (int i = 1; i < faces.Count; i++)
        {
            float targetY = faces[i].transform.position.y + (i * 2f);
            faces[i].transform.DOMove(
                new Vector3(faces[i].transform.position.x, targetY, faces[i].transform.position.z), 2f);
        }
    }

    void Update()
    {
        starCount.text = star.ToString();
    }

    public void RightButton()
    {
        if (a >= 0 && a < faces.Count && faces[a].GetComponent<Faces>()?.face == FaceState.right)
        {
            Debug.Log("Sağa gidildi");
            trueCount++;
            UpdateStarBasedOnTrueCount();

            jsonManager.level2Data.Lvl2Star = star;
            jsonManager.level2Data.trueCount = trueCount;
            jsonManager.SaveLevel2Data();
        }
        else
        {
            Debug.Log("Sağa gitti ama sola gitmeliydi");
        }
        a++;
    }

    public void LeftButton()
    {
        if (a >= 0 && a < faces.Count && faces[a].GetComponent<Faces>()?.face == FaceState.left)
        {
            Debug.Log("Sola gidildi");
            trueCount++;
            UpdateStarBasedOnTrueCount();

            jsonManager.level2Data.Lvl2Star = star;
            jsonManager.level2Data.trueCount = trueCount;
            jsonManager.SaveLevel2Data();
        }
        else
        {
            Debug.Log("Sola gitti ama sağa gitmeliydi");
        }
        a++;
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
}

