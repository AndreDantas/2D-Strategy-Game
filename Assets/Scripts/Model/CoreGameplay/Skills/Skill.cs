using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;
using System;
[System.Serializable]
public abstract class Skill : ScriptableObject
{

    public const int MAX_SKILL_POWER = 999;

    public new string name = "";

    [TextArea(5, 10)]
    public string description = "";

    public enum SkillType { Physical, Magical }

    public SkillType type;

    protected Character caster;

    [SerializeField, HideInInspector] private int _effectPower;

    [ShowInInspector] public int effectPower { get => _effectPower; set => _effectPower = Mathf.Clamp(value, 0, MAX_SKILL_POWER); }
    [SerializeField, HideInInspector] private int _range;

    [ShowInInspector] public int range { get => _range; set => _range = Math.Max(value, 0); }

    public enum PossibleTargets { Self, Allies, Enemies, All }

    /// <summary>
    /// What characters the skill can affect.
    /// </summary>
    public PossibleTargets possibleTargets = PossibleTargets.Enemies;

    public void SetCaster(Character character)
    {
        caster = character;
    }

    public abstract List<MapNode> getAffectedTiles(GameMap map, Position targetNode);

}
