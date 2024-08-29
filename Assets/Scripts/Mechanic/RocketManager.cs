using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketManager : MonoBehaviour
{

     
    
    private void OnTriggerEnter(Collider other)
    {
        Planets planetsComponent = other.gameObject.GetComponent<Planets>();
        if (planetsComponent != null)
        {           

            GameManager.Instance.UpdatePlanets();
        }
    }


}