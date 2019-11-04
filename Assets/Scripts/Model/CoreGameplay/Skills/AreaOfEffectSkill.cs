using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UtilityLibrary.Classes;
using Sirenix.OdinInspector;
[System.Serializable]
[CreateAssetMenu(menuName = "Skill/AreaOfEffectSkill")]
public class AreaOfEffectSkill : Skill
{
    public override int range { get => base.range; set => base.range = Mathf.Max(value, 0); }
    public const int MAX_EFFECT_RADIUS = 10;

    [SerializeField, HideInInspector] private int _effectRadius = 1;

    public AreaOfEffectSkill(int range, int effectRadius)
    {
        this.range = range;
        this.effectRadius = effectRadius;

    }

    public AreaOfEffectSkill()
    {
    }

    public AreaOfEffectSkill(
        string name,
        string description,
        SkillType type,
        int effectPower,
        int range,
        PossibleTargets possibleTargets,
        bool requireTarget) : base(name, description, type, effectPower, range, possibleTargets, requireTarget)
    {
    }

    [ShowInInspector] public int effectRadius { get => _effectRadius; set => _effectRadius = Mathf.Clamp(value, 0, MAX_EFFECT_RADIUS); }

    public override List<MapNode> GetAffectedTiles(GameMap map, Position origin, Position target)
    {
        if (map == null)
            return null;

        var positions = BreadthFirstSearch.FindRange(
                target,
                effectRadius,
                (pos) => (!map.GetNode(pos)?.blocked ?? false),
                (pos) => 1,
                (pos) => map.getNodeNeighbors(pos).ConvertAll(node => node.pos));

        return map.GetNodes(positions);

    }

#if UNITY_EDITOR
    [TableMatrix(DrawElementMethod = "DrawEffect", SquareCells = true)]
    [ShowInInspector]
    public override bool[,] effectDrawing
    {
        get
        {
            int size = effectRadius <= 1 ? 5 : effectRadius * 2 + 3;
            var d = new bool[size, size];
            var pos = new Position((size - 1) / 2, (size - 1) / 2);
            foreach (var node in GetAffectedTiles(new GameMap(size, size), pos, pos))
            {
                d[node.pos.x, node.pos.y] = true;
            }
            return d;
        }
    }
#endif
}
