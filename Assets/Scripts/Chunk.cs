using UnityEngine;

namespace DefaultNamespace
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private Hex _hex;
        [SerializeField] private Transform[] _bindPoints;
        
        private static float R = 170;
        private static Vector3[] directions = new Vector3[]
        {
            new( 1.5f * R, 0,  Mathf.Sqrt(3)/2 * R),
            new( 0,        0,  Mathf.Sqrt(3)   * R),
            new(-1.5f * R, 0,  Mathf.Sqrt(3)/2 * R),
            new(-1.5f * R, 0, -Mathf.Sqrt(3)/2 * R),
            new( 0,        0, -Mathf.Sqrt(3)   * R),
            new( 1.5f * R, 0, -Mathf.Sqrt(3)/2 * R),
        };

        private void Awake()
        {
            _hex.Radius = R;
        }

        public Vector3 GetNeighbourPosition(int neighbourIndex)
        {
            var position = transform.position;
            position += directions[neighbourIndex];
            return position;
        }
    }
}