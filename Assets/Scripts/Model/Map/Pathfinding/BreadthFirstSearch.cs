using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityLibrary;
using UtilityLibrary.Classes;

namespace Pathfinding
{

    public static class BreadthFirstSearch
    {
        /// <summary>
        /// Returns all positions that can be reached from starting point. 
        /// </summary>
        /// <param name="start">The start position</param>
        /// <param name="maxRange">The maximum range from start to a point.</param>
        /// <param name="validPosition">Function to check if position is valid.</param>
        /// <param name="getPositionCost">Function to get the cost to reach the position.</param>
        /// <param name="getNeighbors">Function to get the position's neighbors.</param>
        /// <returns></returns>
        public static List<Position> FindRange(
            Position start,
            int maxRange,
            Func<Position, bool> validPosition,
            Func<Position, int> getPositionCost,
            Func<Position, List<Position>> getNeighbors)
        {

            maxRange = Mathf.Max(maxRange, 0);
            var result = new List<Position>();
            var distDict = new Dictionary<Position, int>();
            var open = new Queue<Position>();

            open.Enqueue(start);
            distDict[start] = 0;
            while (open.Count > 0)
            {
                var pos = open.Dequeue();

                if ((validPosition?.Invoke(pos) ?? false) && !result.Contains(pos))
                {
                    var dist = distDict.GetValueOrDefault(pos, int.MaxValue);

                    if (dist <= maxRange)
                    {
                        result.Add(pos);
                        foreach (var item in getNeighbors?.Invoke(pos))
                        {
                            if (!result.Contains(item) && !open.Contains(item))
                            {
                                open.Enqueue(item);
                                var alt = (getPositionCost?.Invoke(item) ?? int.MaxValue) + dist;
                                if (alt < distDict.GetValueOrDefault(item, int.MaxValue))
                                    distDict[item] = alt;
                            }
                        }
                    }

                }
            }
            return result;
        }

    }
}
