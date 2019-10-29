using UnityEngine;
using Model.Util;
using Core.Util;
[System.Serializable]
public class GameMap : BaseMap
{

    [SerializeField, HideInInspector] private MapNode[,] _nodes = new MapNode[0, 0];
    public MapNode[,] nodes { get => _nodes; private set => _nodes = value; }

    public GameMap()
    {

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
        if (!_nodes?.ValidCoordinates(pos.x, pos.y) ?? true)
            return null;

        return _nodes[pos.x, pos.y];

    }

}
