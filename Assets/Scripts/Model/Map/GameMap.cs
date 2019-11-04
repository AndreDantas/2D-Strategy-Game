using UnityEngine;
using System.Collections.Generic;
using UtilityLibrary.Classes;
using UtilityLibrary;
[System.Serializable]
public class GameMap : BaseMap
{

    [SerializeField, HideInInspector] private MapNode[,] _nodes = new MapNode[0, 0];
    public MapNode[,] nodes { get => _nodes; private set => _nodes = value; }

    public GameMap()
    {
        InitNodes();
    }

    public GameMap(int width, int height) : base(width, height)
    {
        InitNodes();
    }

    protected virtual void InitNodes()
    {
        _nodes = new MapNode[width, height];

        for (int i = 0; i < _nodes.GetLength(0); i++)
        {
            for (int j = 0; j < _nodes.GetLength(1); j++)
            {
                _nodes[i, j] = new MapNode(new Position(i, j));
            }
        }
    }

    public MapNode GetNode(Position pos)
    {
        if (!nodes?.ValidCoordinates(pos.x, pos.y) ?? true)
            return null;

        return nodes[pos.x, pos.y];

    }
    public List<MapNode> GetNodes(List<Position> positions)
    {
        if (positions == null)
            return null;
        var result = new List<MapNode>();
        for (int i = 0; i < positions.Count; i++)
        {
            result.AddNotNull(GetNode(positions[i]));
        }

        return result;

    }

    public virtual List<MapNode> getNodeNeighbors(Position pos)
    {
        var result = new List<MapNode>();

        if (nodes?.ValidCoordinates(pos.x, pos.y) ?? false)
            for (int i = -1; i < 2; i += 2)
            {
                result.AddNotNull(GetNode(new Position(pos.x + i, pos.y)));
                result.AddNotNull(GetNode(new Position(pos.x, pos.y + i)));
            }

        return result;
    }

    public static int GetDistance(Position a, Position b)
    {
        return Mathf.Abs(b.x - a.x) + Mathf.Abs(b.y - a.y);
    }

}
