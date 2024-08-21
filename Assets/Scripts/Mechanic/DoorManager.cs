using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void IncreaseScaleDoor()
    {
        transform.DOScale(new Vector3(2.75f, 2.75f, 2.75f), 3.5f).OnComplete(() =>
        {
            Destroy(gameObject);
        }
        );
    }
}
