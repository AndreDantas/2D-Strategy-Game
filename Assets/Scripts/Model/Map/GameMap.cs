using UnityEngine;
using Sirenix.OdinInspector;
using Util;
[System.Serializable]
public class GameMap : BaseMap
{

    [SerializeField, HideInInspector] private MapNode[,] nodes = new MapNode[0, 0];
    public MapNode[,] Nodes { get => nodes; private set => nodes = value; }

    public GameMap()
    {

    }

    public GameMap(int width, int height) : base(width, height)
    {
        nodes = new MapNode[width, height];
        initNodes();
    }

    protected virtual void initNodes()
    {
        if (nodes == null)
            return;
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(1); j++)
            {
                nodes[i, j] = new MapNode(new Position(i, j));
            }
        }
    }

}
