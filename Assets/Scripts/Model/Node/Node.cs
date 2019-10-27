using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Util;

public abstract class Node
{
    /// <summary>
    /// Node's coordinates
    /// </summary>
    public Position pos;

    public Node()
    {
    }

    protected Node(Position pos)
    {
        this.pos = pos;
    }

    public override string ToString()
    {
        return "Position: " + pos.ToString();
    }

    public override bool Equals(object obj)
    {
        return obj is Node node &&
               EqualityComparer<Position>.Default.Equals(pos, node.pos);
    }

    public override int GetHashCode()
    {
        return 991532785 + EqualityComparer<Position>.Default.GetHashCode(pos);
    }
}
