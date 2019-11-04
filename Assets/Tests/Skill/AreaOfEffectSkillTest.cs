
using System.Collections.Generic;
using NUnit.Framework;
using UtilityLibrary.Classes;
using UnityEngine;
using UnityEngine.TestTools;

namespace ModelTests
{
    public class AreaOfEffectSkillTest
    {
        private GameMap map_5x5 = new GameMap(5, 5);

        [Test]
        public void GetAffectedTiles_EffectRadius2_Returns13Nodes()
        {
            var aoeSkill = ScriptableObject.CreateInstance<AreaOfEffectSkill>();
            var validPosition = new Position(2, 2);
            aoeSkill.effectRadius = 2;
            var nodes = aoeSkill.GetAffectedTiles(map_5x5, validPosition, validPosition);

            Assert.True(nodes.Count == 13);
        }
        [Test]
        public void GetTargetableTiles_Range1_Returns5Nodes()
        {
            var aoeSkill = ScriptableObject.CreateInstance<AreaOfEffectSkill>();
            var validPosition = new Position(2, 2);
            aoeSkill.range = 1;
            var nodes = aoeSkill.GetTargetableTiles(map_5x5, validPosition);

            Assert.True(nodes.Count == 5);
        }

    }
}
