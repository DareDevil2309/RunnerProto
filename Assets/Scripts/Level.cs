using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [Header("Path")] [SerializeField] private int _pointsCount;
        [SerializeField] private int _pointRadius;
        [SerializeField] private int _pathLength;
        [SerializeField] private int _pathSeed;
        [Header("Buildings")]
        [SerializeField] private int _sizeX;
        [SerializeField] private int _sizeY;
        [SerializeField] private float _cellSize;
        [SerializeField] private float _maxHeight;
        [SerializeField] private int _seed = 0;

        private Spline _path;
        
        public void GeneratePath()
        {
            _path = SplineGenerator.Generate(_pathLength, _pointsCount, _pointRadius, _pathSeed);
            GetComponent<SplineContainer>().Spline = _path;
        }
        
        public void GenerateBuildings()
        {
            var mesh = MeshGenerator.Generate(_sizeX, _sizeY, _cellSize, _maxHeight, _seed);
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
}