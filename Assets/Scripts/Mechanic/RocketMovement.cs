using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RocketMovement : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;


    public JSonManagerRocket jSonManagerRocket;

    [SerializeField] private GameObject _doorClose;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(_touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.GetComponent<Planets>())
                {

                    GameObject _hitPlanet = hit.collider.GetComponent<Planets>()._rocketUpPos;
                    GameObject _firstPos = hit.collider.GetComponent<Planets>()._rocketFirstPos;

                    Planets planetsComponent = hit.collider.gameObject.GetComponent<Planets>();


                    GoPlanet(_hitPlanet.transform.position,
                        _hitPlanet.transform.rotation,
                        _firstPos.transform.position,
                        _firstPos.transform.rotation,
                        hit.collider.gameObject.GetComponent<Planets>().lvlID.ToString(),

                     planetsComponent

                        );

                }
            }
        }
    }




    public void GoPlanet(Vector3 upPos, Quaternion _childRot, Vector3 firstPos, Quaternion lastRot, string lvlName, Planets planetsComponent)
    {
        List<Vector3> positions = new List<Vector3>();

        positions.Add(firstPos);
        positions.Add(upPos);


        _rocket.transform.DOPath(positions.ToArray(), 4f, PathType.CatmullRom).SetLookAt(.1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _rocket.transform.DOMove(firstPos, 1f).SetEase(Ease.InExpo).OnComplete(() =>
            {
                jSonManagerRocket.Save();

                if (planetsComponent != null)
                {
                    StartCoroutine(Door(lvlName));

                }
                else
                {
                    Debug.LogError("Planets component is null!");
                }

                // Update planet information in the game manager
                GameManager.Instance.UpdatePlanets();


            });
        }
        );

    }




    IEnumerator Door(string lvlName)
    {
        yield return new WaitForSeconds(.5f);
        _doorClose.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(lvlName);

    }
}

