using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class JSonCharacterManager : MonoBehaviour
{

    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/CharacterData.json";
        LoadCharacterData();
    }

    [ContextMenu("Save Character")]
    public void SaveCharacterData()
    {
        CharacterDatas characterDatas = new CharacterDatas();
        characterDatas.characters = new List<CharacterData>();

        foreach (var item in GameObject.FindObjectsOfType<CharactersType>())
        {
            characterDatas.characters.Add(new CharacterData(item.characterName, item.activeCharacter));
        }

        string json = JsonUtility.ToJson(characterDatas, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Character data saved.");
    }

    private void LoadCharacterData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CharacterDatas data = JsonUtility.FromJson<CharacterDatas>(json);

            foreach (var item in data.characters)
            {
                foreach (var character in GameObject.FindObjectsOfType<CharactersType>())
                {
                    if (item.characterName == character.characterName)
                    {
                        character.activeCharacter = item.activeCharacter;
                        Debug.Log("Character data loaded.");
                        break;
                    }
                }
            }



        }
        else
        {
            Debug.LogWarning("No character data file found.");
        }
    }
}
