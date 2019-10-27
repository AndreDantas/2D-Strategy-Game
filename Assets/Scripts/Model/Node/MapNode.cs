using System.Collections;

using UnityEngine;
using Sirenix.OdinInspector;
using Util;

[System.Serializable]
public class MapNode : Node
{
    public string terrainType = "";

    /// <summary>
    /// If the node is walkable.
    /// </summary>
    public bool walkable = false;

    private const float MIN_WALK_COST = 0f;
    private const float MAX_WALK_COST = 999f;

    [SerializeField, HideInInspector] private float _walkCost = 0f;

    public MapNode()
    {
    }

    public MapNode(Position pos) : base(pos)
    {
    }

    public MapNode(Position pos, string terrainType, bool walkable, float walkCost) : base(pos)
    {
        this.terrainType = terrainType;
        this.walkable = walkable;
        this.walkCost = walkCost;
    }

    /// <summary>
    /// The walk cost of the node.
    /// </summary>
    /// <value></value>
    [ShowInInspector] public float walkCost { get => _walkCost; set => _walkCost = Mathf.Clamp(value, MIN_WALK_COST, MAX_WALK_COST); }


    public override string ToString()
    {
        return string.Format(base.ToString() + "\nTerrain type: %s\nWalkable: %b\nWalk cost: %f", terrainType, walkable, walkCost);
    }
}
