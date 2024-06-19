using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Type Writer Script, Author : witnn .

[RequireComponent(typeof(AudioSource))]
public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip TypeSound;
    [Multiline]
    public string yazi;



    AudioSource audSrc;
    TextMeshProUGUI thisText;

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<TextMeshProUGUI>();

        StartCoroutine(SecondTypeWrite());
    }

    IEnumerator SecondTypeWrite()
    {
        foreach (char i in yazi)
        {
            thisText.text += i.ToString();

            audSrc.pitch = Random.Range(0.8f, 1.2f);
            audSrc.PlayOneShot(TypeSound);

            if (i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }
        }
    }
}