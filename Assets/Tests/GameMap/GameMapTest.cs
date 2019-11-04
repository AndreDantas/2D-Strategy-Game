using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UtilityLibrary.Classes;

namespace ModelTests
{

    public class GameMapTest
    {

        private GameMap map_5x5 = new GameMap(5, 5);

        [Test]
        public void Constructor_InitiateNodes_NodesArrayNotNull()
        {
            Assert.IsNotNull(map_5x5.nodes);
        }

        [Test]
        public void Constructor_InitiateNodes_AllNodesCreated()
        {

            bool allNodesCreated = true;

            for (int i = 0; i < map_5x5.nodes.GetLength(0); i++)
            {
                for (int j = 0; j < map_5x5.nodes.GetLength(1); j++)
                {
                    if (map_5x5.nodes[i, j] == null)
                    {
                        allNodesCreated = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(allNodesCreated);
        }
        [Test]
        public void GetNode_InvalidPosition_ReturnsNull()
        {

            var invalidPosition = new Position(-1, -1);

            Assert.IsNull(map_5x5.GetNode(invalidPosition));

        }
        [Test]
        public void GetNode_ValidPosition_ReturnsNode()
        {

            var validPosition = new Position(0, 0);

            Assert.IsNotNull(map_5x5.GetNode(validPosition));

        }
        [Test]
        public void GetNodes_InvalidPositions_ReturnsZeroNodes()
        {
            var invalidPositions = new List<Position> { new Position(-1, -1), new Position(0, -1), new Position(-1, 0) };

            Assert.IsEmpty(map_5x5.GetNodes(invalidPositions));
        }
        [Test]
        public void GetNodes_ValidPositions_ReturnsNodes()
        {
            var validPositions = new List<Position> { new Position(0, 0), new Position(0, 1), new Position(1, 1) };

            Assert.IsNotEmpty(map_5x5.GetNodes(validPositions));
        }
        [Test]
        public void GetNodeNeighbors_CenterPosition_Returns4Nodes()
        {
            var validPosition = new Position(2, 2);

            Assert.True(map_5x5.getNodeNeighbors(validPosition).Count == 4);
        }
        [Test]
        public void GetDistance_BottomLeftCornerToBottomRightCorner_Returns4()
        {
            var bottomLeftPosition = new Position(0, 0);
            var bottomRightPosition = new Position(4, 0);

            Assert.True(GameMap.GetDistance(bottomLeftPosition, bottomRightPosition) == 4);
        }
    }
}
