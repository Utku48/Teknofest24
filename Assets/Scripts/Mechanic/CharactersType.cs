
using UnityEngine;

public class CharactersType : MonoBehaviour
{
    public CharacterName characterName;
    
    public int IdCharacter;


    public bool activeCharacter = false;

    public enum CharacterName
    {
        boy,
        girl,
        astronaut,
        alien,
        fox
    }


    public CharacterName _characterName()
    {
        
        return characterName;
        
    }


 

}
