using System.Collections;
using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using UtilityLibrary;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;

[System.Serializable]
[CreateAssetMenu(menuName = "Skill/LineSkill")]
public class LineSkill : Skill
{
    [ReadOnly] public override int range { get => 1; set { } }
    [SerializeField, HideInInspector] private int _lineReach = 1;

    public bool passThroughBlock = false;
    [ShowInInspector] public int lineReach { get => _lineReach; set => _lineReach = Mathf.Max(value, 1); }

    public LineSkill(int range, int lineReach, bool passThroughBlock)
    {
        this.range = range;
        this.passThroughBlock = passThroughBlock;
        this.lineReach = lineReach;
    }

    public LineSkill(
        string name,
        string description,
        SkillType type,
        int effectPower,
        int range,
        PossibleTargets possibleTargets,
        bool requireTarget) : base(name, description, type, effectPower, range, possibleTargets, requireTarget)
    {
    }

    public override List<MapNode> GetAffectedTiles(GameMap map, Position origin, Position target)
    {
        var result = new List<MapNode>();

        if (map == null)
            return result;

        var dir = GetCardinalDirection(origin, target);
        for (int i = 0; i < lineReach; i++)
        {
            var node = map.GetNode(new Position(target.x + dir.x * i, target.y + dir.y * i));
            if (node != null)
            {
                if (!node.blocked)
                    result.AddNotNull(node);
                else if (!passThroughBlock)
                    break;
            }
            else
                break;
        }
        return result;
    }

    public override List<MapNode> GetTargetableTiles(GameMap map, Position origin)
    {
        var newList = base.GetTargetableTiles(map, origin);
        newList.RemoveAt(0);
        return newList;
    }

    protected static Position GetCardinalDirection(Position origin, Position target)
    {
        if (origin == target)
            return Position.Up;

        if (Mathf.Abs(target.x - origin.x) <= Mathf.Abs(target.y - origin.y)) // Vertical Line
        {
            if (target.y > origin.y) // Up
            {
                return Position.Up;
            }
            else // Down
            {
                return Position.Down;
            }
        }
        else // Horizontal Line
        {
            if (target.x > origin.x) // Right
            {
                return Position.Right;
            }
            else // Left
            {
                return Position.Left;
            }
        }
    }

#if UNITY_EDITOR
    [TableMatrix(DrawElementMethod = "DrawEffect", SquareCells = true, Transpose = true)]
    [ShowInInspector]
    public override bool[,] effectDrawing
    {
        get
        {
            int size = lineReach <= 2 ? 5 : lineReach * 2 - 1;
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
