using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


public class RocketMovement : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private Transform _target;
    public bool rotate = true;


 

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(_touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject _hitPlanet = hit.collider.gameObject;

                if (_hitPlanet.GetComponent<Planets>())
                {
                    rotate = !rotate;
                    GoPlanet(_hitPlanet.transform.position);

                }

            }
        }
    }


    public void GoPlanet(Vector3 _planetPos)
    {

        _rocket.transform.DOMove(_planetPos, 1f);
    }


}