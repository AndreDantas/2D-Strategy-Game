using Sirenix.OdinInspector;
using UnityEngine;
namespace Model.Util
{
    [System.Serializable]
    public struct Position
    {
        public Position(int x, int y)
        {
            _x = 0;
            _y = 0;

            this.x = x;
            this.y = y;
        }

        [SerializeField, HideInInspector] private int _x;
        [SerializeField, HideInInspector] private int _y;

        /// <summary>
        /// X coordinate.
        /// </summary>
        [ShowInInspector] public int x { get => _x; private set => _x = value; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        [ShowInInspector] public int y { get => _y; private set => _y = value; }

        public override string ToString()
        {
            return string.Format("(%d,%d)", x, y);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   x == position.x &&
                   y == position.y;
        }

        public override int GetHashCode()
        {
            var hashCode = 9356714;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
    }
}
