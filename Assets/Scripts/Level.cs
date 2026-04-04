using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Path _path;
        [SerializeField] private City _city;
        [SerializeField] private ChunksPool _chunksPool;

        private Hex[] _hexes;
        
        public void Generate()
        {
            // _path.Generate();
            // _city.Generate();
            GenerateHexes();
        }

        public void GenerateHexes()
        {
            var root = _chunksPool.GetRandomChunk();

            for (int i = 0; i < Hex.NEIGHBOURS_COUNT; i++)
            {
                var neighbour = _chunksPool.GetRandomChunk();
                neighbour.transform.position = root.GetNeighbourPosition(i);
            }
        }
    }
}