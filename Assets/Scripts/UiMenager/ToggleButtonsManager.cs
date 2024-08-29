using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;

    void Start()
    {
        if (parentObject == null)
        {
            parentObject = this.gameObject;
        }
    }

    public void OnPressed()
    {
        bool anyToggleOn = false;

       
        foreach (Transform child in parentObject.transform)
        {
            Toggle toggle = child.gameObject.GetComponent<Toggle>();

            if (toggle != null && toggle.isOn)
            {
                anyToggleOn = true;
                break;
            }
        }

        foreach (Transform child in parentObject.transform)
        {
            Toggle toggle = child.gameObject.GetComponent<Toggle>();
            if (toggle != null)
            {
                toggle.interactable = !anyToggleOn || toggle.isOn;
            }
        }
    }
}
