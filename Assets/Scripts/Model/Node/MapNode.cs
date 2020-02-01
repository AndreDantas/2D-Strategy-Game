using UnityEngine;
using System;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;
using System.Collections.Generic;

[System.Serializable]
public class MapNode : Node, IEquatable<MapNode>
{
    public string terrainType;

    /// <summary>
    /// If the node is blocked.
    /// </summary>
    public bool blocked = false;

    public Character character;

    private const float MIN_WALK_COST = 0;
    private const float MAX_WALK_COST = 99;

    [SerializeField, HideInInspector] private float _walkCost = 0;

    public MapNode()
    {
    }

    public MapNode(Position pos) : base(pos)
    {
    }

    public MapNode(Position pos, string terrainType, bool blocked, float walkCost) : base(pos)
    {
        this.terrainType = terrainType;
        this.blocked = blocked;
        this.walkCost = walkCost;
    }

    public MapNode(MapNode other) : this(other.pos, other.terrainType, other.blocked, other.walkCost)
    {

    }

    /// <summary>
    /// The walk cost of the node.
    /// </summary>
    /// <value></value>
    [ShowInInspector] public float walkCost { get => _walkCost; set => _walkCost = Mathf.Clamp(value, MIN_WALK_COST, MAX_WALK_COST); }


    public override string ToString()
    {
        return base.ToString() + " - Terrain type: " + terrainType + " - Blocked: " + blocked + " - Walk cost: " + walkCost;
    }

    public bool Equals(MapNode other)
    {
        return this.pos == other.pos;
    }
}
