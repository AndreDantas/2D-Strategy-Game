using System.Collections;

using UnityEngine;
using Sirenix.OdinInspector;
public class MapNode : Node
{
    /// <summary>
    /// If the node is walkable.
    /// </summary>
    public bool walkable;

    private const float MIN_WALK_COST = 0f;
    private const float MAX_WALK_COST = 999f;

    [SerializeField, HideInInspector] private float _walkCost;

    /// <summary>
    /// The walk cost of the node.
    /// </summary>
    /// <value></value>
    [ShowInInspector] public float walkCost { get => _walkCost; set => _walkCost = Mathf.Clamp(value, MIN_WALK_COST, MAX_WALK_COST); }
}
