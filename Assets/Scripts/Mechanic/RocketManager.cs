using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketManager : MonoBehaviour
{


    [SerializeField] private Camera _cam;



    private void Start()
    {
        _cam = Camera.main;

    }

    //OnComplate ile level aç

    private void OnTriggerEnter(Collider other)
    {
        Planets planetsComponent = other.gameObject.GetComponent<Planets>();
        if (planetsComponent != null)
        {
            

            GameManager.Instance.UpdatePlanets();
        }
    }

    private void MoveCamera()
    {
        _cam.transform.DOMove(new Vector3(_cam.transform.position.x, _cam.transform.position.y + 1.5f, _cam.transform.position.z), 3f);
    }


}