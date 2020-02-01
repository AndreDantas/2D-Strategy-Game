using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityLibrary;
using Sirenix.OdinInspector;
public class CharacterController : MonoBehaviour
{
    public Character character;
    public CharacterView characterView;

    private void Awake()
    {
        characterView = gameObject.GetOrAddComponent<CharacterView>();
    }
}
