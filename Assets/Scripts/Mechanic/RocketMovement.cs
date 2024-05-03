using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RocketMovement : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;


    public JSonManagerRocket jSonManagerRocket;



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

                    GameObject _hitPlanet = hit.collider.gameObject.transform.GetChild(0).gameObject;

                    Planets planetsComponent = hit.collider.gameObject.GetComponent<Planets>();


                    GoPlanet(_hitPlanet.transform.position,
                        _hitPlanet.transform.rotation,
                        hit.collider.gameObject.GetComponent<Planets>().lvlID.ToString(),

                     planetsComponent

                        );


                }
            }
        }
    }


    public void GoPlanet(Vector3 _childPos, Quaternion _childRot, string lvlName, Planets planetsComponent)
    {
        // Sequence ile yap

        _rocket.transform.DOMove(_childPos, 1f).SetEase(Ease.Linear);
        _rocket.transform.DORotate(_childRot.eulerAngles, 1.5f)
            .OnComplete(() =>
            {

                jSonManagerRocket.Save();

                if (planetsComponent != null)
                {

                }
                else
                {
                    Debug.LogError("Planets component is null!");
                }
                SceneManager.LoadScene(lvlName);
            });

        GameManager.Instance.UpdatePlanets();
    }







}