using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject parentPanel;


    public Animator transition
;
    void Start()
    {

    }


    void Update()
    {

    }

    #region MainSceneButtonController
    public void MainSceneStart()
    {

        StartCoroutine(ClickStartButton(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ParentButton()
    {
        if (!parentPanel.activeInHierarchy)
            parentPanel.SetActive(true);
    }

    public void ParentPanelClose()
    {
        if (parentPanel.activeInHierarchy)
        {
            parentPanel.SetActive(false);
        }
    }
    IEnumerator ClickStartButton(int levelIndex)
    {

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.25f);

        SceneManager.LoadScene(levelIndex);
    }


    public void DeleteAllJsonFiles()
    {
        // JSON dosyalarının kaydedildiği klasör yolu
        string folderPath = Application.persistentDataPath;

        if (Directory.Exists(folderPath))
        {
            // Tüm JSON dosyalarını al
            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

            // Her bir JSON dosyasını sil
            foreach (string file in jsonFiles)
            {
                File.Delete(file);
            }

            Debug.Log("Tüm JSON dosyaları başarıyla silindi.");
        }
        else
        {
            Debug.LogError("Klasör bulunamadı: " + folderPath);
        }
    }


    #endregion
}
