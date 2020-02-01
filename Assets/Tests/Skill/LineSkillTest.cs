using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UtilityLibrary.Classes;
using UnityEngine;
using UnityEngine.TestTools;

namespace ModelTests
{
    public class LineSkillTest
    {

        private GameMap map_5x5 = new GameMap(5, 5);

        [Test]
        public void GetAffectedTiles_lineReach5_Returns5Nodes()
        {
            var lineSkill = ScriptableObject.CreateInstance<LineSkill>();
            var validPosition = new Position(0, 0);
            lineSkill.lineReach = 5;
            var nodes = lineSkill.GetAffectedTiles(map_5x5, validPosition, validPosition);

            Assert.True(nodes.Count == 5);
        }
        [Test]
        public void GetTargetableTiles_Returns4Nodes()
        {
            var lineSkill = ScriptableObject.CreateInstance<LineSkill>();
            var validPosition = new Position(2, 2);
            var nodes = lineSkill.GetTargetableTiles(map_5x5, validPosition);

            Assert.True(nodes.Count == 4);
        }

    }
}
