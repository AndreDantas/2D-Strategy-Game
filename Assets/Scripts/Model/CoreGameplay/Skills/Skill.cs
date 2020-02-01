using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;
using Pathfinding;
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
    [ShowInInspector] public virtual int range { get => _range; set => _range = value; }

    public enum PossibleTargets { Self, Allies, Enemies, All }

    /// <summary>
    /// What characters the skill can affect.
    /// </summary>
    public PossibleTargets possibleTargets = PossibleTargets.Enemies;

    /// <summary>
    /// Skill will only activate if there are targets availables.
    /// </summary>
    public bool requireTarget = true;

    public Skill()
    {
    }

    protected Skill(
        string name,
        string description,
        SkillType type,
        int effectPower,
        int range,
        PossibleTargets possibleTargets,
        bool requireTarget)
    {
        this.name = name;
        this.description = description;
        this.type = type;
        this.effectPower = effectPower;
        this.range = range;
        this.possibleTargets = possibleTargets;
        this.requireTarget = requireTarget;
    }


    public Skill SetCaster(Character character)
    {
        caster = character;
        return this;
    }

    /// <summary>
    /// Returns all tiles that are going to be affected by skill.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="origin">Skill's casting origin.</param>
    /// <param name="target">Skill's target tile.</param>
    /// <returns></returns>
    public abstract List<MapNode> GetAffectedTiles(GameMap map, Position origin, Position target);

    /// <summary>
    /// Returns all targetable tiles in the skill range.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="origin">Skill's casting origin.</param>
    /// <returns></returns>
    public virtual List<MapNode> GetTargetableTiles(GameMap map, Position origin)
    {
        if (map == null)
            return null;

        var positions = BreadthFirstSearch.FindRange(
                origin,
                range,
                (pos) => (!map.GetNode(pos)?.blocked ?? false),
                (pos) => 1,
                (pos) => map.getNodeNeighbors(pos).ConvertAll(node => node.pos));

        return map.GetNodes(positions);


    }

#if UNITY_EDITOR
    [TableMatrix(DrawElementMethod = "DrawEffect")]
    [ShowInInspector]
    public virtual bool[,] effectDrawing
    {
        get;
    }

    protected static bool DrawEffect(Rect rect, bool value)
    {
        EditorGUI.DrawRect(rect,
        value ? new Color(0.8f, 0.2f, 0.1f, 0.5f) : new Color(0, 0, 0, 0.5f));
        return value;
    }
#endif

}
