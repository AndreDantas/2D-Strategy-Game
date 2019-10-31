using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;

[System.Serializable]
[CreateAssetMenu(menuName = "Skill/LineSkill")]
public class LineSkill : Skill
{
    [HideInInspector] public new const int range = 1;
    [SerializeField, HideInInspector] private int _lineReach;

    [ShowInInspector] public int lineReach { get => _lineReach; set => _lineReach = Mathf.Max(value, 1); }

    public override List<MapNode> getAffectedTiles(GameMap map, Position origin, Position target)
    {
        if (map == null)
            return null;


        throw new System.NotImplementedException();
    }
}
