using UnityEngine;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;

[System.Serializable]
public class MapNode : Node
{
    public string terrainType = "";

    /// <summary>
    /// If the node is walkable.
    /// </summary>
    public bool walkable = false;

    private const int MIN_WALK_COST = 0;
    private const int MAX_WALK_COST = 99;

    [SerializeField, HideInInspector] private int _walkCost = 0;

    public MapNode()
    {
    }

    public MapNode(Position pos) : base(pos)
    {
    }

    public MapNode(Position pos, string terrainType, bool walkable, int walkCost) : base(pos)
    {
        this.terrainType = terrainType;
        this.walkable = walkable;
        this.walkCost = walkCost;
    }

    /// <summary>
    /// The walk cost of the node.
    /// </summary>
    /// <value></value>
    [ShowInInspector] public int walkCost { get => _walkCost; set => _walkCost = Mathf.Clamp(value, MIN_WALK_COST, MAX_WALK_COST); }


    public override string ToString()
    {
        return string.Format(base.ToString() + "\nTerrain type: %s\nWalkable: %b\nWalk cost: %d", terrainType, walkable, walkCost);
    }
}
