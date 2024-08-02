using System.Collections.Generic;

[System.Serializable]
public class CharacterData
{
    public CharactersType.CharacterName characterName;
    public bool activeCharacter;


    public CharacterData(CharactersType.CharacterName name, bool isActive)
    {
        characterName = name;
        activeCharacter = isActive;
    }


}


[System.Serializable]
public class CharacterDatas
{
    public List<CharacterData> characters;
}
