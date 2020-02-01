using System.Collections.Generic;
using UtilityLibrary;
using UtilityLibrary.Classes;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;


public static class GridToMapConverter
{
    [System.Serializable]
    private class NodeInfo
    {
        
        public string terrainType = "Unknown";
        public bool blocked = true;
        public float walkCost = 1;

        public NodeInfo()
        {
        }

        public NodeInfo(NodeInfo other)
        {
            terrainType = other.terrainType;
            blocked = other.blocked;
            walkCost = other.walkCost;
        }
    }
    [System.Serializable]
    private class NodeList
    {
        public List<NodeInfo> nodes = new List<NodeInfo>();
    }
    /// <summary>
    /// Converts grid tiles into a GameMap. The tiles are converted to MapNodes by comparing their name and checking for a match in a json file in the Resources folder.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="mapArea"></param>
    /// <param name="nodesReferencePath"></param>
    /// <returns></returns>
    public static GameMap Convert(Grid grid, BoundsInt mapArea, string nodesReferencePath = "Nodes")
    {
        if (!grid)
            return null;
        mapArea = new BoundsInt(mapArea.position, new Vector3Int(mapArea.size.x, mapArea.size.y, 1));
        GameMap map = new GameMap(mapArea.size.x, mapArea.size.y);
        var json = Resources.Load<TextAsset>("Nodes/" + nodesReferencePath.Replace(".json", ""));

        var nodeList = JsonUtility.FromJson<NodeList>(json?.text);

        var tileMaps = grid.GetComponentsInChildren<Tilemap>().ToList();

        tileMaps.Sort((t1, t2) =>
        {
            var tr1 = t1.GetComponent<TilemapRenderer>();
            var tr2 = t2.GetComponent<TilemapRenderer>();

            return (tr1?.sortingOrder ?? 0).CompareTo(tr2?.sortingOrder ?? 0);
        });

        foreach (var tm in tileMaps)
        {
            var tiles = tm.GetTilesBlock(mapArea);
            for (int x = 0; x < mapArea.size.x; x++)
            {
                for (int y = 0; y < mapArea.size.y; y++)
                {

                    var tile = tiles[x + y * mapArea.size.x];

                    if (tile != null)
                    {
                        NodeInfo nodeInfo = nodeList.nodes.Find(node => tile.name.ToLower().Contains(node?.terrainType.ToLower()));
                        if (nodeInfo != null)
                            map.nodes[x, y] = BuildMapNode(nodeInfo, new Position(x, y));
                    }

                    if (string.IsNullOrEmpty(map.nodes[x, y].terrainType))
                        map.nodes[x, y] = BuildMapNode(null, new Position(x, y));

                }
            }
        }
        // foreach (var item in map.nodes.GetItems())
        // {
        //     Debug.Log(item);
        // }
        return map;
    }

    private static MapNode BuildMapNode(NodeInfo node,
                                        Position pos = default(Position)) => new MapNode(pos, node?.terrainType ?? "Unknown", node?.blocked ?? true, node?.walkCost ?? 1);
}
