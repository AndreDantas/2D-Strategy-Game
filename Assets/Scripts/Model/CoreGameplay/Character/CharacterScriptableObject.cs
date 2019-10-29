using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class CharacterScriptableObject : ScriptableObject
{

    public Character character = new Character();
    public List<Skill> skills = new List<Skill>();
}
