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
        GameManager.Instance.planets[planetIndex].GetComponent<SphereCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Planets planetsComponent = other.gameObject.GetComponent<Planets>();
        if (planetsComponent != null)
        {


            RotateRocket();
            MoveCamera();
            EnablePlanetColliders();

            StartCoroutine(LoadScene(other.gameObject.GetComponent<Planets>().item.ToString(), other.gameObject));//Roketin Gezegen Level'ına girmesi
            jsonManager.Save();

        }
    }

    private void RotateRocket()
    {

    }

    private void MoveCamera()
    {
        _cam.transform.DOMove(new Vector3(_cam.transform.position.x, _cam.transform.position.y + 1.5f, _cam.transform.position.z), 3f);
    }

    private void EnablePlanetColliders()
    {
        GameManager.Instance.planets[planetIndex + 1].gameObject.GetComponent<SphereCollider>().enabled = true;
        planetIndex++;


    }




    IEnumerator LoadScene(string levelName, GameObject currentLevel)
    {

        currentLevel.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);

    }

}
