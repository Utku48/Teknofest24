
using UnityEngine;

public class CharactersType : MonoBehaviour
{
    public CharacterEnum characterType;

    public enum CharacterEnum
    {
        boy,
        girl,
        astronaut,
        alien,
        fox
    }


    public CharacterEnum _characterType()
    {
        return characterType;
    }

}
