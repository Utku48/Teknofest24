
using UnityEngine;

public class CharactersType : MonoBehaviour
{
    public CharacterName characterName;



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
