using System.Collections.Generic;
using UnityEngine;
using UtilityLibrary;
using UtilityLibrary.Classes;
using Sirenix.OdinInspector;
[System.Serializable]
[CreateAssetMenu(menuName = "Skill/AreaOfEffectSkill")]
public class AreaOfEffectSkill : Skill
{

    [SerializeField, HideInInspector] private int _effectRadius;

    [ShowInInspector] public int effectRadius { get => _effectRadius; set => _effectRadius = Mathf.Max(value, 0); }

#if UNITY_EDITOR
    [TableMatrix(DrawElementMethod = "DrawEffect", SquareCells = true)]
    [ShowInInspector]
    public override bool[,] effectDrawing
    {
        get
        {
            int size = effectRadius <= 1 ? 5 : effectRadius * 2 + 3;
            var d = new bool[size, size];
            var pos = new Position((size - 1) / 2, (size - 1) / 2);
            foreach (var node in getAffectedTiles(new GameMap(size, size), pos, pos))
            {
                d[node.pos.x, node.pos.y] = true;
            }
            return d;
        }
    }
#endif
    public override List<MapNode> getAffectedTiles(GameMap map, Position origin, Position target)
    {
        if (map == null)
            return null;

        var check = new List<MapNode>();
        var checkLater = new List<MapNode>();
        var result = new List<MapNode>();

        check.AddNotNull(map.GetNode(target));

        for (int i = 0; i <= effectRadius; i++)
        {
            for (int j = check.Count - 1; j >= 0; j--)
            {
                var node = check[j];
                check.RemoveAt(j);
                if (node != null && !result.Contains(node))
                {
                    result.Add(node);
                    if (i < effectRadius)
                        foreach (var item in map.getNodeNeighbors(node.pos))
                        {
                            if (!result.Contains(item))
                            {
                                checkLater.AddNotNull(item);
                            }
                        }
                }

            }
            check.TryAddRange(checkLater);
            checkLater.Clear();
            if (check.Count == 0)
                break;
        };

        return result;
    }
}
