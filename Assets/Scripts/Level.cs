using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _sizeX;
        [SerializeField] private int _sizeY;
        [SerializeField] private float _cellSize;
        [SerializeField] private float _maxHeight;
        [SerializeField] private int _seed = 0;
        
        public void GenerateLevel()
        {
            var mesh = MeshGenerator.Generate(_sizeX, _sizeY, _cellSize, _maxHeight);
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
}