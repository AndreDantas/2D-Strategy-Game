using UnityEngine;
using Sirenix.OdinInspector;
using Core.Util;
public class MapView : MonoBehaviour
{

    public GameMap map = new GameMap(5, 5);

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (map != null)
        {
            var scale = 1f;
            for (int i = 0; i < map.width; i++)
            {
                for (int j = 0; j < map.height; j++)
                {
                    UtilityFunctions.GizmosDrawSquare(transform.position + new Vector3(i, j, 0) + new Vector3(scale / 2f, scale / 2f, 0), scale);
                }
            }
        }
    }
#endif

}
