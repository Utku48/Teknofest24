using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketManager : MonoBehaviour
{
    public JSonManagerRocket jsonManager;

    [SerializeField] private Camera _cam;

    private int planetIndex = 0;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        Planets planetsComponent = other.gameObject.GetComponent<Planets>();
        if (planetsComponent != null)
        {
            RotateRocket();
            MoveCamera();
            DisablePlanetColliders();

            // Increment planet index or reset if it exceeds the count
            planetIndex = (planetIndex + 1) % GameManager.Instance.planets.Count;

            jsonManager.Save();
        }
    }

    private void RotateRocket()
    {
        Vector3 rotation = (planetIndex % 2 == 0) ? new Vector3(0f, 180f, -60f) : new Vector3(0f, 180f, 60f);
        transform.DORotate(rotation, 2f);
    }

    private void MoveCamera()
    {
        _cam.transform.DOMove(new Vector3(_cam.transform.position.x, _cam.transform.position.y + 1.5f, _cam.transform.position.z), 3f);
    }

    private void DisablePlanetColliders()
    {
        foreach (GameObject planet in GameManager.Instance.planets)
        {
            planet.GetComponent<SphereCollider>().enabled = false;
        }
        GameManager.Instance.planets[planetIndex].GetComponent<SphereCollider>().enabled = true;
    }




    IEnumerator LoadScene(string levelName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);

    }

}
