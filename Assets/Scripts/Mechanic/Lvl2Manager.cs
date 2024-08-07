using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Faces;

public class Lvl2Manager : MonoBehaviour
{
    public List<GameObject> faces = new List<GameObject>();

    public int a;

    void Start()
    {
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

    }


    public void RightButton()
    {
        if (faces[a].GetComponent<Faces>().face == FaceState.right)
        {
            Debug.Log("sağa gidildi");
        }
        else
        {
            Debug.Log("sağa gitti ama sola gitmeliydi");
        }
        a++;

    }

    public void LeftButton()
    {
        if (faces[a].GetComponent<Faces>().face == FaceState.left)
        {
            Debug.Log("Sola Gidildi");
        }
        else
        {
            Debug.Log("Sola gitti ama sola gitmeliydi");
        }
        a++;
    }

}
