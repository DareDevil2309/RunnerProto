using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ChunksPool", menuName = "Chunks Pool")]
    public class ChunksPool : ScriptableObject
    {
        [SerializeField] private Chunk[] _chunkPrefabs;

        public Chunk GetRandomChunk()
        {
            System.Random rand = new System.Random();
            var prefabIndex = rand.Next(_chunkPrefabs.Length);
            var chunk = Instantiate(_chunkPrefabs[prefabIndex]);
            return chunk;
        }
    }
}