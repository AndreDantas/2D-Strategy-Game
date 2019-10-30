using System.Collections;
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

    public override List<MapNode> getAffectedTiles(GameMap map, Position targetPos)
    {
        if (map == null)
            return null;

        var check = new List<MapNode>();
        var checkLater = new List<MapNode>();
        var result = new List<MapNode>();

        check.AddNotNull(map.GetNode(targetPos));

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
