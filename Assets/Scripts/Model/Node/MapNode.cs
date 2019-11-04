using UnityEngine;
using System;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;
using System.Collections.Generic;

[System.Serializable]
public class MapNode : Node, IEquatable<MapNode>
{
    public string terrainType = "";

    /// <summary>
    /// If the node is blocked.
    /// </summary>
    public bool blocked = false;

    private const int MIN_WALK_COST = 0;
    private const int MAX_WALK_COST = 99;

    [SerializeField, HideInInspector] private int _walkCost = 0;

    public MapNode()
    {
    }

    public MapNode(Position pos) : base(pos)
    {
    }

    public MapNode(Position pos, string terrainType, bool blocked, int walkCost) : base(pos)
    {
        this.terrainType = terrainType;
        this.blocked = blocked;
        this.walkCost = walkCost;
    }

    /// <summary>
    /// The walk cost of the node.
    /// </summary>
    /// <value></value>
    [ShowInInspector] public int walkCost { get => _walkCost; set => _walkCost = Mathf.Clamp(value, MIN_WALK_COST, MAX_WALK_COST); }


    public override string ToString()
    {
        return base.ToString() + "\nTerrain type: " + terrainType + "\nBlocked: " + blocked + "\nWalk cost: " + walkCost;
    }

    public bool Equals(MapNode other)
    {
        return this.pos == other.pos;
    }
}
