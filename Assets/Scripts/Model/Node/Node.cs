using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Model.Util;
[System.Serializable]
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
        return "Node " + pos.ToString();
    }

}
